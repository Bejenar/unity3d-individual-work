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
        public RangedAttackType attackType = RangedAttackType.Spawn;
    }
    
    public enum RangedAttackType
    {
        Spawn,
        Projectile
    }
    
    public class TagHealAttack : EntityComponentDefinition
    {
        public AutoDestroyVFX healEffect;
    }
}