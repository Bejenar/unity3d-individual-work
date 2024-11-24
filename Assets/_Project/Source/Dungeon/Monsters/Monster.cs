using System;
using _Project.Data.Monsters;

[Serializable]
public class Monster : Unit
{
    public float GutsAmount;

    public Monster(BaseMonsterEntity model)
    {
        this.model = model;
        Initialize();
    }

    public void Initialize()
    {
        Gold = model.Get<TagCoinDrop>().coins;
        Column = model.Get<TagPosition>().column;
        MaxHealth = model.Get<TagBaseStats>().maxHealth;
        Health = MaxHealth;
        DamageRange = model.Get<TagBaseStats>().damageRange;
        Evasion = model.Get<TagBaseStats>().evasion;
        DamageReduction = model.Get<TagBaseStats>().damageReduction;
        HitChance = model.Get<TagBaseStats>().hitChance;
        CritChance = model.Get<TagBaseStats>().critChance;
        Blockage = model.Get<TagBaseStats>().blockage;
        GutsAmount = model.Get<TagBaseStats>().gutsAmount;
    }

    
}