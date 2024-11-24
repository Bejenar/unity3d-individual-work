using _Project.Data.Items;
using _Project.Data.Traits;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Source.Dungeon.Battle
{
    public interface IDamageModifier
    {
        float ModifyDamage(DungeonCharacter caster, DungeonCharacter target, float damage);
    }

    public class CriticalDamageModifier : BaseInteraction, IDamageModifier
    {
        public float ModifyDamage(DungeonCharacter caster, DungeonCharacter target, float damage)
        {
            // TODO this interaction should not know about TagCurseNoLuck? 
            // maybe we should have ICritScaleModifier
            if (caster.unit.Traits.Is<TagCurseNoLuck>(out _))
            {
                return damage;
            }

            if (Random.value < caster.unit.CritChance)
            {
                caster.ChangeMorale(1).Forget(); //TODO forget?

                return damage * 2;
            }

            return damage;
        }
    }
}