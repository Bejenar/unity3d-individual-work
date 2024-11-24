using System.Collections.Generic;

namespace _Project.Data
{
    public class TagLevelProgression : EntityComponentDefinition
    {
        public List<LevelDefinition> levels = new List<LevelDefinition>();
    }

    public class LevelDefinition
    {
        public float maxHealth;
        public float hitChance;
        public float critChance;
        public float evasion;
        public float blockage;
        public float baseDamageMin;
        public float baseDamageMax;
        public float maxMorale;
        public float moraleBoostOnWin;
        public float damageReduction;
        
        public override string ToString()
        {
            return $"maxHealth: {maxHealth}, hitChance: {hitChance}, critChance: {critChance}, evasion: {evasion}, blockage: {blockage}, baseDamageMin: {baseDamageMin}, baseDamageMax: {baseDamageMax}, maxMorale: {maxMorale}, moraleBoostOnWin: {moraleBoostOnWin}, damageReduction: {damageReduction}";
        }
    }
}