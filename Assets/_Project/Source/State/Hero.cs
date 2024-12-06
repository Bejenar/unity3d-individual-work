using System;
using _Project.Data;
using _Project.Data.Items;
using _Project.Data.Traits;
using Newtonsoft.Json;
using UnityEngine;

namespace _Project.Source
{
    [Serializable]
    public class Hero : Unit
    {
        [JsonIgnore]
        public readonly int[] EXPERIENCE_LEVELS = {0, 10, 40, 80, 150, 330, 600, 1000, 1500, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000};
        
        public BaseWeaponEntity Weapon;
        
        public BaseArmorEntity Armor;
        
        public BaseRingEntity Ring;

        public string name;
        public float sanity = 20;

        public int Level;
        public string Title;
        public int MaxMorale;
        public int Morale;
        public int GutsAmount;
        public int Experience;
        public int MaximumClearedLevel = -1;
        public int MoraleBoostOnWin;
        public string Id;
        public string CharacterClass;
        public int Age = 18;

        // public int SkinIndex;
        // public string ConsumableId;


        public string LastAttackerName;
        public Vector2 LastVillagePosition;

        public int HiringCost = 5;

        public readonly float DefaultMoraleDamageMultiplier = 1;
        public float MoraleDamageMultiplier;

        public int SessionGold;
        public bool fled = false;
        public bool died = false;

        public Color hairColor;
        
        public Hero()
        {
        }

        public Hero(BaseHeroClass model)
        {
            Id = Guid.NewGuid().ToString();
            this.model = model;
            name = NameGenerator.GetRandomNameByClass(model.Get<TagClass>().loc);
            Level = 0;
            UpdateStats();
        }

        public void LevelUp()
        {
            Debug.Log("Level up");
            Level++;
            UpdateStats();
        }

        public void UpdateStats()
        {
            var levelProgression = model.Get<TagLevelProgression>();

            var idx = Mathf.Min(Level, levelProgression.levels.Count - 1);
            var levelDefinition = levelProgression.levels[idx];
            MaxHealth = (int)levelDefinition.maxHealth;
            Health = MaxHealth;
            HitChance = levelDefinition.hitChance;
            CritChance = levelDefinition.critChance;
            Evasion = levelDefinition.evasion;
            Blockage = levelDefinition.blockage;
            DamageRange = new Vector2(levelDefinition.baseDamageMin, levelDefinition.baseDamageMax);
            MaxMorale = (int)levelDefinition.maxMorale;
            Morale = MaxMorale;
            MoraleBoostOnWin = (int)levelDefinition.moraleBoostOnWin;
            DamageReduction = (int)levelDefinition.damageReduction;
            MoraleDamageMultiplier = DefaultMoraleDamageMultiplier;

            if (Armor != null)
            {
                MaxHealth += Armor.Get<TagArmor>().health;
                Health += Armor.Get<TagArmor>().health;
                Evasion += Armor.Get<TagArmor>().evasion;
                DamageReduction += Armor.Get<TagArmor>().damageReduction;
                Blockage += Armor.Get<TagArmor>().blockage;
            }

            if (Weapon != null)
            {
                var weaponRange = Weapon.Get<TagWeaponDamage>().range;
                DamageRange = new Vector2(DamageRange.x + weaponRange.x, DamageRange.y + weaponRange.y);
            }

            if (Ring != null)
            {
                if (Ring.Is<TagStatsBuff>(out var buff))
                    BuffStats(buff);
            }

            Traits.GetAll<TagStatsBuff>().ForEach(BuffStats);
            Traits.GetAll<TagStatsOverrideBuff>().ForEach(OverrideStats);
        }

        public void BuffStats(TagStatsBuff buff)
        {
            HitChance += buff.hitChance;
            CritChance += buff.critChance;
            Evasion += buff.evasion;
            DamageReduction += buff.damageReduction;
            HealthRegeneration += buff.healthRegen;
            Blockage += buff.blockage;
            MaxHealth += buff.health;
            Health += buff.health;
            DamageRange = new Vector2(DamageRange.x + buff.damage.x, DamageRange.y + buff.damage.y);
        }

        public void OverrideStats(TagStatsOverrideBuff overrideBuff)
        {
            MoraleDamageMultiplier = overrideBuff.moraleDamageMultiplier;
        }

        public void UpdateTraitsNewYear()
        {
            Traits.Remove<TagWitnessedDeathNow>();
        }

        public void WitnessDeath(DeceasedHero deceasedHero)
        {
            Traits.GetOrAdd(CMS.Get<WitnessedDeathTrait>())
                .GetOrAdd<WitnessedDeathState>().deceasedHeroes.Add(deceasedHero);
            Traits.GetOrAdd(CMS.Get<WitnessedDeathNowTrait>())
                .GetOrAdd<WitnessedDeathState>().deceasedHeroes.Add(deceasedHero);
        }

        public void AddTrait<T>() where T : CMSEntity
        {
            Traits.GetOrAdd(CMS.Get<T>());
        }

        public void AddGold(int amount)
        {
            SessionGold += amount;
        }

        public void OnDungeonClear()
        {
            Experience += SessionGold;
            while (Experience >= EXPERIENCE_LEVELS[Level + 1])
            {
                LevelUp();
            }

            var tax = Mathf.CeilToInt(SessionGold * 0.12f);
            G.state.gold += tax;
            Gold += SessionGold - tax;
            SessionGold = 0;
            fled = false;
            died = false;
            sanity = 20;
        }
    }

    [Serializable]
    public class DeceasedHero
    {
        public int tombPlace;

        public String name;
    }
}