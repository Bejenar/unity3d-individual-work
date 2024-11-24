using _Project.Source.Dungeon.Battle;
using UnityEngine.VFX;

namespace _Project.Data
{
    public class TagMeleeAttack : EntityComponentDefinition
    {
    }
    
    public class TagRangedAttack : EntityComponentDefinition
    {
    }
    
    public class TagAoeAttack : EntityComponentDefinition
    {
        public AutoDestroyVFX effectPerUnitHit;
    }
    
    public class TagHealAttack : EntityComponentDefinition
    {
        public AutoDestroyVFX healEffect;
    }
}