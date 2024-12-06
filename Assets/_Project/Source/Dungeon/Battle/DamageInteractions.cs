using _Project.Data.Items;
using _Project.Data.Traits;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Source.Dungeon.Battle
{
    public interface IDamageModifier
    {
        (float, FieldData.AttackResult) ModifyDamage(DungeonCharacter caster, DungeonCharacter target, float damage, FieldData.AttackResult res);
    }

    public class CriticalDamageModifier : BaseInteraction, IDamageModifier
    {
        public (float, FieldData.AttackResult) ModifyDamage(DungeonCharacter caster, DungeonCharacter target, float damage, FieldData.AttackResult res)
        {
            // TODO this interaction should not know about TagCurseNoLuck? 
            // maybe we should have ICritScaleModifier
            if (caster.unit.Traits.Is<TagCurseNoLuck>(out _))
            {
                return (damage, res);
            }

            if (Random.value < caster.unit.CritChance)
            {
                caster.ChangeMorale(1).Forget(); //TODO forget?

                return (damage * 2, res | FieldData.AttackResult.Critical);
            }

            return (damage, res);
        }
    }
}