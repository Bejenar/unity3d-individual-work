using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Data.Items
{
    public class TagItemName : EntityComponentDefinition
    {
        public string name;
    }

    public class TagWeaponDamage : EntityComponentDefinition
    {
        public Vector2Int range;
    }

    public class TagPrice : EntityComponentDefinition
    {
        public int price;
    }

    public class TagTier : EntityComponentDefinition
    {
        public int tier;
    }

    public class TagEquipableBy : EntityComponentDefinition
    {
        // count 0 = by all
        public List<Type> classes = new();
    }
    
    public class TagStatsBuff : EntityComponentDefinition
    {
        public int health;
        public int healthRegen;
        public Vector2Int damage;
        public float hitChance;
        public float critChance;
        public int damageReduction;
        public float evasion;
        public float blockage;
    }
    
    public class TagStatsOverrideBuff : EntityComponentDefinition
    {
        public float moraleDamageMultiplier;
    }
    
    public class TagArmor : EntityComponentDefinition
    {
        public int health;
        public int damageReduction;
        public float evasion;
        public float blockage;
    }

}