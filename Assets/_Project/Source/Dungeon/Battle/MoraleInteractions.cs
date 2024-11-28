using _Project.Data.Items;
using _Project.Data.Traits;
using _Project.Source.Scenes;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Source.Dungeon.Battle
{
    
    public interface IOnMoraleHit
    {
        UniTask OnMoraleHit(DungeonHero character, int change);
    }

    public interface IAfterMoraleHit
    {
        UniTask AfterMoraleHit(FieldData data, DungeonHero character);
    }
    
    public class DefaultOnMoraleHit : BaseInteraction, IOnMoraleHit
    {
        public async UniTask OnMoraleHit(DungeonHero character, int change)
        {
            change = Mathf.RoundToInt(character.hero.MoraleDamageMultiplier * change);
            character.hero.Morale = Mathf.Clamp(character.hero.Morale + change, 0, character.hero.MaxMorale);
            await UniTask.CompletedTask;
        }
    }

    public class DefaultAfterMoraleHit : BaseInteraction, IAfterMoraleHit
    {
        public async UniTask AfterMoraleHit(FieldData fieldData, DungeonHero character)
        {
            if (character.fleeing) return;
            
            if (character.hero.Morale <= 0)
            {
                Debug.Log($"{character.name} has fled!");
                fieldData.OnHeroFled(character);
                await character.Flee();
            }
        }
    }
    
    public class RationalAfterMoraleHit : BaseInteraction, IAfterMoraleHit
    {
        public async UniTask AfterMoraleHit(FieldData fieldData, DungeonHero character)
        {
            if (character.fleeing) return;
            
            if (character.hero.Health < character.hero.Morale && character.hero.Health/character.hero.MaxHealth < 0.2f)
            {
                Debug.Log($"{character.name} has rationally fled!");
                fieldData.OnHeroFled(character);
                await character.Flee();
            }
        }
    }
    
    public class RevengefulInteraction : BaseInteraction, IAfterMoraleHit
    {
        public static readonly string[] REVENGEFUL_LINES =
        {
            "I will avenge you!",
            "I will not surrender!",
            "Your death will not be in vain!"
        };

        public override int Priority()
        {
            return PriorityLayers.FIRST;
        }

        public async UniTask AfterMoraleHit(FieldData fieldData, DungeonHero character)
        {
            var hero = character.hero;

            if (!(hero.Traits.Is(out TagRevengeful _) &&
                  hero.Traits.IsWithState<TagWitnessedDeathNow, WitnessedDeathState>(out var s) &&
                  s.deceasedHeroes.Count > 0)) return;

            if (hero.Morale <= 0)
            {
                hero.Morale = 1;
                Debug.Log($"{character.name} {REVENGEFUL_LINES.GetRandom()}");
            }

            await UniTask.CompletedTask;
        }
    }
}