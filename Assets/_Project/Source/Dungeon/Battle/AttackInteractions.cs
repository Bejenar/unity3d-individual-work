using System.Collections.Generic;
using System.Linq;
using System.Threading;
using _Project.Data;
using _Project.Data.Items;
using _Project.Source.Village.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Project.Source.Dungeon.Battle
{
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
            if (!actor.unit.model.Is<T>(out var val)) return;


            Debug.Log("Attacking: " + actor.name);
            await OnAttack(data, actor, val);
        }

        public abstract UniTask OnAttack(FieldData data, DungeonCharacter actor, T tag);
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

            var dmg = await FieldData.TryAttack(actor, target);
            
            await UniTask.WaitUntilCanceled(actor.AttackAnimation());

            // TODO evade block miss?
            G.dungeon.hud.ShowDamageText((int)-dmg, target.transform.position, target is DungeonHero, false);
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

            var dmg = await FieldData.TryAttack(actor, target);

            await UniTask.WaitUntilCanceled(actor.AttackAnimation());

            // TODO evade block miss?
            G.dungeon.hud.ShowDamageText((int)-dmg, target.transform.position, target is DungeonHero, false);
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
                // TODO spawn particles under each target
                var dmg = await FieldData.TryAttack(actor, target);
                
                // TODO evade block miss?
                var vfx = Object.Instantiate(tag.effectPerUnitHit, target.transform);
                vfx.transform.SetParent(null);
                G.dungeon.hud.ShowDamageText((int)-dmg, target.transform.position, target is DungeonHero, false);
                
                await UniTask.WhenAll(
                    target.TakeDamage(dmg),
                    UniTask.WaitForSeconds(vfx.duration));
            }).ToArray();

            await UniTask.WhenAll(tasks);
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

            // TODO spawn heal particles under target
            Debug.Log("Healing: " + heal);
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