using System;
using System.Collections.Generic;
using _Project.Data.Traits;
using UnityEngine;

namespace _Project.Data.Items
{
    [Serializable]
    public abstract class BaseWeaponEntity : CMSEntity
    {
        public BaseWeaponEntity()
        {
            Define<TagItemName>().name = "Default Weapon";
            Define<TagWeaponDamage>().range = new Vector2Int(1, 1);
            Define<TagPrice>().price = 0;
            Define<TagTier>().tier = 1;
            Define<TagEquipableBy>().classes = new List<Type>();
        }
    }
    
    public class Excalibur : BaseWeaponEntity
    {
        public Excalibur()
        {
            Define<TagItemName>().name = "Excalibur";
            Define<TagWeaponDamage>().range = new Vector2Int(10, 10);
            Define<TagPrice>().price = 5;
            Define<TagTier>().tier = 1;
        }
    }

    public class HeroTrait : CMSEntity
    {
        public HeroTrait()
        {
            Define<TagTraitView>().name = "Default Trait";
            Define<TagStatsBuff>().health = 20;
            Define<TagStatsBuff>().damage = new Vector2Int(20, 20);
            Define<TagStatsBuff>().evasion = 0.3f;
            Define<TagStatsBuff>().critChance = 0.3f;
            
        }
    }


    public class IronSword : BaseWeaponEntity
    {
        public IronSword()
        {
            Define<TagItemName>().name = "Iron Sword";
            Define<TagWeaponDamage>().range = new Vector2Int(1, 2);
            Define<TagPrice>().price = 5;
            Define<TagTier>().tier = 1;
            Define<TagEquipableBy>().classes.Add(typeof(Tank));
        }
    }


    public class SteelSword : BaseWeaponEntity
    {
        public SteelSword()
        {
            Define<TagItemName>().name = "Steel Sword";
            Define<TagWeaponDamage>().range = new Vector2Int(2, 4);
            Define<TagPrice>().price = 30;
            Define<TagTier>().tier = 2;
            Define<TagEquipableBy>().classes.Add(typeof(Tank));
        }
    }

    public class DamasceneSword : BaseWeaponEntity
    {
        public DamasceneSword()
        {
            Define<TagItemName>().name = "Damascene Sword";
            Define<TagWeaponDamage>().range = new Vector2Int(3, 5);
            Define<TagPrice>().price = 75;
            Define<TagTier>().tier = 3;
            Define<TagEquipableBy>().classes.Add(typeof(Tank));
        }
    }

    public class Pitchfork : BaseWeaponEntity
    {
        public Pitchfork()
        {
            Define<TagItemName>().name = "Pitchfork";
            Define<TagWeaponDamage>().range = new Vector2Int(0, 2);
            Define<TagPrice>().price = 5;
            Define<TagTier>().tier = 1;
            Define<TagEquipableBy>().classes.Add(typeof(Captain));
        }
    }

    public class Greatspear : BaseWeaponEntity
    {
        public Greatspear()
        {
            Define<TagItemName>().name = "Greatspear";
            Define<TagWeaponDamage>().range = new Vector2Int(1, 3);
            Define<TagPrice>().price = 30;
            Define<TagTier>().tier = 2;
            Define<TagEquipableBy>().classes.Add(typeof(Captain));
        }
    }

    public class GrandHalberd : BaseWeaponEntity
    {
        public GrandHalberd()
        {
            Define<TagItemName>().name = "Grand Halberd";
            Define<TagWeaponDamage>().range = new Vector2Int(1, 4);
            Define<TagPrice>().price = 75;
            Define<TagTier>().tier = 3;
            Define<TagEquipableBy>().classes.Add(typeof(Captain));
        }
    }

    public class WoodcutterAxe : BaseWeaponEntity
    {
        public WoodcutterAxe()
        {
            Define<TagItemName>().name = "Woodcutter Axe";
            Define<TagWeaponDamage>().range = new Vector2Int(2, 4);
            Define<TagPrice>().price = 5;
            Define<TagTier>().tier = 1;
            Define<TagEquipableBy>().classes.Add(typeof(Barbarian));
        }
    }

    public class Battleaxe : BaseWeaponEntity
    {
        public Battleaxe()
        {
            Define<TagItemName>().name = "Battleaxe";
            Define<TagWeaponDamage>().range = new Vector2Int(3, 8);
            Define<TagPrice>().price = 30;
            Define<TagTier>().tier = 2;
            Define<TagEquipableBy>().classes.Add(typeof(Barbarian));
        }
    }

    public class ChampionsAxe : BaseWeaponEntity
    {
        public ChampionsAxe()
        {
            Define<TagItemName>().name = "Champion's Axe";
            Define<TagWeaponDamage>().range = new Vector2Int(4, 12);
            Define<TagPrice>().price = 75;
            Define<TagTier>().tier = 3;
            Define<TagEquipableBy>().classes.Add(typeof(Barbarian));
        }
    }

    public class OldCrossbow : BaseWeaponEntity
    {
        public OldCrossbow()
        {
            Define<TagItemName>().name = "Old Crossbow";
            Define<TagWeaponDamage>().range = new Vector2Int(1, 3);
            Define<TagPrice>().price = 5;
            Define<TagTier>().tier = 1;
            Define<TagEquipableBy>().classes.Add(typeof(Ranger));
        }
    }

    public class SteelCrossbow : BaseWeaponEntity
    {
        public SteelCrossbow()
        {
            Define<TagItemName>().name = "Steel Crossbow";
            Define<TagWeaponDamage>().range = new Vector2Int(3, 6);
            Define<TagPrice>().price = 30;
            Define<TagTier>().tier = 2;
            Define<TagEquipableBy>().classes.Add(typeof(Ranger));
        }
    }

    public class BattleCrossbow : BaseWeaponEntity
    {
        public BattleCrossbow()
        {
            Define<TagItemName>().name = "Battle Crossbow";
            Define<TagWeaponDamage>().range = new Vector2Int(5, 10);
            Define<TagPrice>().price = 75;
            Define<TagTier>().tier = 3;
            Define<TagEquipableBy>().classes.Add(typeof(Ranger));
        }
    }

    public class AshStaff : BaseWeaponEntity
    {
        public AshStaff()
        {
            Define<TagItemName>().name = "Ash Staff";
            Define<TagWeaponDamage>().range = new Vector2Int(0, 2);
            Define<TagPrice>().price = 5;
            Define<TagTier>().tier = 1;
            Define<TagEquipableBy>().classes.Add(typeof(Mage));
        }
    }

    public class CherryStaff : BaseWeaponEntity
    {
        public CherryStaff()
        {
            Define<TagItemName>().name = "Cherry Staff";
            Define<TagWeaponDamage>().range = new Vector2Int(1, 4);
            Define<TagPrice>().price = 30;
            Define<TagTier>().tier = 2;
            Define<TagEquipableBy>().classes.Add(typeof(Mage));
        }
    }

    public class EbonyStaff : BaseWeaponEntity
    {
        public EbonyStaff()
        {
            Define<TagItemName>().name = "Ebony Staff";
            Define<TagWeaponDamage>().range = new Vector2Int(2, 6);
            Define<TagPrice>().price = 75;
            Define<TagTier>().tier = 3;
            Define<TagEquipableBy>().classes.Add(typeof(Mage));
        }
    }

    public class StaleMedicine : BaseWeaponEntity
    {
        public StaleMedicine()
        {
            Define<TagItemName>().name = "Stale Medicine";
            Define<TagWeaponDamage>().range = new Vector2Int(0, 2);
            Define<TagPrice>().price = 5;
            Define<TagTier>().tier = 1;
            Define<TagEquipableBy>().classes.Add(typeof(Healer));
        }
    }

    public class FieldMedicine : BaseWeaponEntity
    {
        public FieldMedicine()
        {
            Define<TagItemName>().name = "Field Medicine";
            Define<TagWeaponDamage>().range = new Vector2Int(0, 4);
            Define<TagPrice>().price = 30;
            Define<TagTier>().tier = 2;
            Define<TagEquipableBy>().classes.Add(typeof(Healer));
        }
    }

    public class ExoticMedicine : BaseWeaponEntity
    {
        public ExoticMedicine()
        {
            Define<TagItemName>().name = "Exotic Medicine";
            Define<TagWeaponDamage>().range = new Vector2Int(2, 6);
            Define<TagPrice>().price = 75;
            Define<TagTier>().tier = 3;
            Define<TagEquipableBy>().classes.Add(typeof(Healer));
        }
    }
}