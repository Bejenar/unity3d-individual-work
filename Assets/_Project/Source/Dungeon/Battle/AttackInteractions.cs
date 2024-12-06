using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using _Project.Data;
using _Project.Data.Items;
using _Project.Data.Monsters;
using _Project.Source.Village.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Project.Source.Dungeon.Battle
{
    public interface IOnAttack
    {
        UniTask OnAttack(FieldData data, DungeonCharacter actor);
    }
    
    public class RegenerationInteraction : BaseInteraction, IOnAttack
    {
        public async UniTask OnAttack(FieldData data, DungeonCharacter actor)
        {
            if (actor.unit.HealthRegeneration > 0)
            {
                Debug.Log("Regeneration");
                await actor.Heal(actor.unit.HealthRegeneration);
            }
        }

        public override int Priority()
        {
            return PriorityLayers.FIRST;
        }
    }

    public class MoralDegradation : BaseInteraction, IOnAttack
    {
        public async UniTask OnAttack(FieldData data, DungeonCharacter actor)
        {
            if (actor is not DungeonHero hero) return;

            hero.attacksPerformed++;
            var moralDegradationChance = (hero.attacksPerformed - 10) * 0.04f;
            if (Random.value < moralDegradationChance)
            {
                var moraleChange = Random.value < moralDegradationChance ? -4 : -2;
                await hero.ChangeMorale(moraleChange);
            }
        }
    }

    public abstract class AttackInteraction<T> : BaseInteraction, IOnAttack where T : EntityComponentDefinition, new()
    {
        public async UniTask OnAttack(FieldData data, DungeonCharacter actor)
        {
            if (!actor.IsParticipating()) return;
            
            if (!actor.unit.model.Is<T>(out var val)) return;
            
            Debug.Log("Attacking: " + actor.name);
            await OnAttack(data, actor, val);
        }

        public abstract UniTask OnAttack(FieldData data, DungeonCharacter actor, T tag);

        public static void ResolveDamageText(float dmg, FieldData.AttackResult result, Vector3 position, bool isHero)
        {
            switch (result)
            {
                case var p when (p & FieldData.AttackResult.Damage) == FieldData.AttackResult.Damage:
                    G.dungeon.hud.ShowDamageText((int)-dmg, position, isHero, p.HasFlag(FieldData.AttackResult.Critical));
                    break;
                case FieldData.AttackResult.Missed:
                    G.dungeon.hud.ShowMissText(position);
                    break;
                case FieldData.AttackResult.Blocked:
                    G.dungeon.hud.ShowBlockText(position);
                    break;
                case FieldData.AttackResult.Evaded:
                    G.dungeon.hud.ShowEvadeText(position);
                    break;
            }
        }
    }

    public class MeleeAttackInteraction : AttackInteraction<TagMeleeAttack>
    {
        public override async UniTask OnAttack(FieldData data, DungeonCharacter actor, TagMeleeAttack tag)
        {
            var target = data.GetEnemyTargets(actor).GetRandom();

            if (!target)
            {
                return;
            }

            var (dmg, res)  = await FieldData.TryAttack(actor, target);
            
            await UniTask.WaitUntilCanceled(actor.AttackAnimation());

            ResolveDamageText(dmg, res, target.transform.position, target is DungeonHero);
            await target.TakeDamage(dmg);
        }
    }


    public class RangeAttackInteraction : AttackInteraction<TagRangedAttack>
    {
        public override async UniTask OnAttack(FieldData data, DungeonCharacter actor, TagRangedAttack tag)
        {
            Debug.Log("RANGE ATTACK");
            var target = data.GetEnemyTargets(actor).GetRandom();

            if (!target)
            {
                return;
            }

            var (dmg, res) = await FieldData.TryAttack(actor, target);

            await UniTask.WaitUntilCanceled(actor.AttackAnimation());

            ResolveDamageText(dmg, res, target.transform.position, target is DungeonHero);
            await target.TakeDamage(dmg);
        }
    }

    public class AoeAttackInteraction : AttackInteraction<TagAoeAttack>
    {
        public override async UniTask OnAttack(FieldData data, DungeonCharacter actor, TagAoeAttack tag)
        {
            Debug.Log("AOE ATTACK");
            var targets = data.GetEnemyTargets(actor);
            
            await UniTask.WaitUntilCanceled(actor.MagicAnimation());

            var tasks = targets.Select(async target =>
            {
                var (dmg, res)  = await FieldData.TryAttack(actor, target);
                
                ResolveDamageText(dmg, res, target.transform.position, target is DungeonHero);
                
                await UniTask.WhenAll(
                    target.TakeDamage(dmg),
                    SpawnVFX(actor, tag, target));
            }).ToArray();

            await UniTask.WhenAll(tasks);
        }

        private async UniTask SpawnVFX(DungeonCharacter actor, TagAoeAttack tag, DungeonCharacter target)
        {
            var vfxInteractors = G.interactor.FindAll<IAttackEffectBehavior>();
            foreach (var vfxInteractor in vfxInteractors)
            {
                await vfxInteractor.Execute(actor, target, tag);
            }
        }
    }

    public class HealInteraction : AttackInteraction<TagHealAttack>
    {
        public override async UniTask OnAttack(FieldData data, DungeonCharacter actor, TagHealAttack tag)
        {
            Debug.Log("HEAL ATTACK");
            var target = GetWeakestAlly(data.GetAllyTargets(actor));

            if (!target)
            {
                return;
            }

            var heal = FieldData.RandomRange(actor.unit.DamageRange);

            await UniTask.WaitUntilCanceled(actor.MagicAnimation());

            if ((int)heal > 0)
                G.dungeon.hud.ShowDamageText((int)heal, target.transform.position, target is DungeonHero, false);
            else 
                G.dungeon.hud.ShowFailedHealText(target.transform.position);

            var vfx = Object.Instantiate(tag.healEffect, target.transform);
            vfx.transform.SetParent(null);
            await target.Heal(heal);
        }

        private DungeonCharacter GetWeakestAlly(List<DungeonCharacter> targets)
        {
            if (targets.Count <= 0) return null;

            DungeonCharacter weakestCharacter = null;
            var lowestHealth = 1.0f;

            foreach (var ally in targets.Where(ally => ally.unit.RelativeHealth < lowestHealth))
            {
                weakestCharacter = ally;
                lowestHealth = ally.unit.RelativeHealth;
            }

            if (weakestCharacter != null && lowestHealth < 1.0f)
            {
                return weakestCharacter;
            }

            return null;
        }
    }
}