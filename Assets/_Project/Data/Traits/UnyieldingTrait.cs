using _Project.Data.Items;
using _Project.Source;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Data.Traits
{
    public class UnyieldingTrait : CMSEntity
    {
        // if change < 0 && - change >= character.health && character.health != 1:
        // if character.has_trait("unyielding"):
        //     $VisualCharacter.say(TraitEffects.UNYIELDING_LINES.pick_random())
        // change = - character.health + 1
        public UnyieldingTrait()
        {
            Define<TagTraitView>().name = "Unyielding";
            Define<TagUnyielding>();
        }
    }

    public class TagUnyielding : EntityComponentDefinition
    {
    }

    public interface IAfterHealthChange
    {
        UniTask AfterHealthChange(DungeonCharacter hero, float change, bool isCritical = false);
    }

    public class MoraleAfterHealthChange : BaseInteraction, IAfterHealthChange
    {
        public async UniTask AfterHealthChange(DungeonCharacter ch, float change, bool isCritical = false)
        {
            if (ch is not DungeonHero hero) return;

            var unit = ch.unit;
            int moraleHit = unit.RelativeHealth switch
            {
                <= 0.15f => 10,
                <= 0.28f => 6,
                <= 0.5f => 4,
                <= 0.7f => 2,
                <= 0.85f => 1,
                _ => 0
            };

            if (isCritical) moraleHit += 4;

            if (change < 0)
                await hero.ChangeMorale(-moraleHit);
            else
                await hero.ChangeMorale(Mathf.FloorToInt(moraleHit * 0.8f));
        }
    }

    public class UnyieldingInteraction : BaseInteraction, IAfterHealthChange
    {
        // private readonly string[] UNYIELDING_LINES = new[]
        // {
        //     "I will not yield!"
        // };

        public async UniTask AfterHealthChange(DungeonCharacter ch, float change, bool isCritical = false)
        {
            if (ch.unit is not Hero hero) return;
            if (!hero.Traits.Is(out TagUnyielding _)) return;

            if (change < 0 && -change >= hero.Health && !Mathf.Approximately(hero.Health, 1))
            {
                Debug.Log("(1) Unyielding trait activated on " + hero.name + ". Current health " + hero.Health);
                // $VisualCharacter.say(TraitEffects.UNYIELDING_LINES.pick_random());
                hero.Health = -change + 1;
                Debug.Log("(2) Unyielding trait activated on " + ch.IsParticipating() + ". New health " + hero.Health);
                
                ch.UpdateUI();
            }

            await UniTask.CompletedTask;
        }
    }
}