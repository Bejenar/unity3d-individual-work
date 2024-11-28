using System;

namespace _Project.Data.Items
{
    [Serializable]
    public abstract class BaseArmorEntity : CMSEntity
    {
        public BaseArmorEntity()
        {
            Define<TagItemName>();
            Define<TagPrice>();
            Define<TagArmor>();
            Define<TagTier>();
            Define<TagEquipableBy>();
        }
    }

    public class Chainmail : BaseArmorEntity
    {
        public Chainmail()
        {
            Define<TagItemName>().name = "Chainmail";
            Define<TagArmor>().health = 10;
            Define<TagArmor>().evasion = 0;
            Define<TagArmor>().damageReduction = 1;
            Define<TagArmor>().blockage = 5;
            Define<TagPrice>().price = 5;
            Define<TagTier>().tier = 1;
            Define<TagEquipableBy>().classes.Add(typeof(Tank));
        }
    }

    public class Brigandine : BaseArmorEntity
    {
        public Brigandine()
        {
            Define<TagItemName>().name = "Brigandine";
            Define<TagArmor>().health = 20;
            Define<TagArmor>().evasion = -0.1f;
            Define<TagArmor>().damageReduction = 3;
            Define<TagArmor>().blockage = 10;
            Define<TagPrice>().price = 30;
            Define<TagTier>().tier = 2;
            Define<TagEquipableBy>().classes.Add(typeof(Tank));
        }
    }

    public class PlateArmor : BaseArmorEntity
    {
        public PlateArmor()
        {
            Define<TagItemName>().name = "Plate Armor";
            Define<TagArmor>().health = 40;
            Define<TagArmor>().evasion = -0.2f;
            Define<TagArmor>().damageReduction = 5;
            Define<TagArmor>().blockage = 0.2f;
            Define<TagPrice>().price = 75;
            Define<TagTier>().tier = 3;
            Define<TagEquipableBy>().classes.Add(typeof(Tank));
        }
    }

    public class CaptainChainMail : BaseArmorEntity
    {
        public CaptainChainMail()
        {
            Define<TagItemName>().name = "Chain Mail";
            Define<TagArmor>().health = 8;
            Define<TagArmor>().evasion = 0;
            Define<TagArmor>().damageReduction = 1;
            Define<TagArmor>().blockage = 0;
            Define<TagPrice>().price = 5;
            Define<TagTier>().tier = 1;
            Define<TagEquipableBy>().classes.Add(typeof(Captain));
        }
    }
    
    public class RingArmor : BaseArmorEntity
    {
        public RingArmor()
        {
            Define<TagItemName>().name = "Ring Armor";
            Define<TagArmor>().health = 15;
            Define<TagArmor>().evasion = 0;
            Define<TagArmor>().damageReduction = 2;
            Define<TagArmor>().blockage = 0.05f;
            Define<TagPrice>().price = 30;
            Define<TagTier>().tier = 2;
            Define<TagEquipableBy>().classes.Add(typeof(Captain));
        }
    }

    public class MailAndPlate : BaseArmorEntity
    {
        public MailAndPlate()
        {
            Define<TagItemName>().name = "Mail and Plate";
            Define<TagArmor>().health = 25;
            Define<TagArmor>().evasion = 0;
            Define<TagArmor>().damageReduction = 3;
            Define<TagArmor>().blockage = 0.1f;
            Define<TagPrice>().price = 75;
            Define<TagTier>().tier = 3;
            Define<TagEquipableBy>().classes.Add(typeof(Captain));
        }
    }

    public class LeatherBraces : BaseArmorEntity
    {
        public LeatherBraces()
        {
            Define<TagItemName>().name = "Leather Braces";
            Define<TagArmor>().health = 5;
            Define<TagArmor>().evasion = 0.1f;
            Define<TagArmor>().damageReduction = 0;
            Define<TagArmor>().blockage = 0;
            Define<TagPrice>().price = 5;
            Define<TagTier>().tier = 1;
            Define<TagEquipableBy>().classes.Add(typeof(Barbarian));
        }
    }

    public class LeatherBreastplate : BaseArmorEntity
    {
        public LeatherBreastplate()
        {
            Define<TagItemName>().name = "Leather Breastplate";
            Define<TagArmor>().health = 10;
            Define<TagArmor>().evasion = 0.2f;
            Define<TagArmor>().damageReduction = 0;
            Define<TagArmor>().blockage = -0.05f;
            Define<TagPrice>().price = 30;
            Define<TagTier>().tier = 2;
            Define<TagEquipableBy>().classes.Add(typeof(Barbarian));
        }
    }

    public class WildlingCuirass : BaseArmorEntity
    {
        public WildlingCuirass()
        {
            Define<TagItemName>().name = "Wildling Cuirass";
            Define<TagArmor>().health = 15;
            Define<TagArmor>().evasion = 0.3f;
            Define<TagArmor>().damageReduction = 0;
            Define<TagArmor>().blockage = -0.1f;
            Define<TagPrice>().price = 75;
            Define<TagTier>().tier = 3;
            Define<TagEquipableBy>().classes.Add(typeof(Barbarian));
        }
    }

    public class LeatherCuirass : BaseArmorEntity
    {
        public LeatherCuirass()
        {
            Define<TagItemName>().name = "Leather Cuirass";
            Define<TagArmor>().health = 5;
            Define<TagArmor>().evasion = 0.1f;
            Define<TagArmor>().damageReduction = 0;
            Define<TagArmor>().blockage = 0;
            Define<TagPrice>().price = 5;
            Define<TagTier>().tier = 1;
            Define<TagEquipableBy>().classes.Add(typeof(Ranger));
        }
    }

    public class HardenedLeather : BaseArmorEntity
    {
        public HardenedLeather()
        {
            Define<TagItemName>().name = "Hardened Leather";
            Define<TagArmor>().health = 10;
            Define<TagArmor>().evasion = 0.2f;
            Define<TagArmor>().damageReduction = 1;
            Define<TagArmor>().blockage = 0;
            Define<TagPrice>().price = 30;
            Define<TagTier>().tier = 2;
            Define<TagEquipableBy>().classes.Add(typeof(Ranger));
        }
    }

    public class MailAndLeather : BaseArmorEntity
    {
        public MailAndLeather()
        {
            Define<TagItemName>().name = "Mail and Leather";
            Define<TagArmor>().health = 15;
            Define<TagArmor>().evasion = 0.3f;
            Define<TagArmor>().damageReduction = 2;
            Define<TagArmor>().blockage = 0;
            Define<TagPrice>().price = 75;
            Define<TagTier>().tier = 3;
            Define<TagEquipableBy>().classes.Add(typeof(Ranger));
        }
    }

    public class LongRobe : BaseArmorEntity
    {
        public LongRobe()
        {
            Define<TagItemName>().name = "Long Robe";
            Define<TagArmor>().health = 4;
            Define<TagArmor>().evasion = 0.1f;
            Define<TagArmor>().damageReduction = 0;
            Define<TagArmor>().blockage = 0;
            Define<TagPrice>().price = 5;
            Define<TagTier>().tier = 1;
            Define<TagEquipableBy>().classes.Add(typeof(Mage));
        }
    }

    public class OrnateRobe : BaseArmorEntity
    {
        public OrnateRobe()
        {
            Define<TagItemName>().name = "Ornate Robe";
            Define<TagArmor>().health = 8;
            Define<TagArmor>().evasion = 0.2f;
            Define<TagArmor>().damageReduction = 0;
            Define<TagArmor>().blockage = 0;
            Define<TagPrice>().price = 30;
            Define<TagTier>().tier = 2;
            Define<TagEquipableBy>().classes.Add(typeof(Mage));
        }
    }

    public class CamouflagedRobe : BaseArmorEntity
    {
        public CamouflagedRobe()
        {
            Define<TagItemName>().name = "Camouflaged Robe";
            Define<TagArmor>().health = 13;
            Define<TagArmor>().evasion = 0.3f;
            Define<TagArmor>().damageReduction = 0;
            Define<TagArmor>().blockage = 0;
            Define<TagPrice>().price = 75;
            Define<TagTier>().tier = 3;
            Define<TagEquipableBy>().classes.Add(typeof(Mage));
        }
    }

    public class Gambeson : BaseArmorEntity
    {
        public Gambeson()
        {
            Define<TagItemName>().name = "Gambeson";
            Define<TagArmor>().health = 6;
            Define<TagArmor>().evasion = 0;
            Define<TagArmor>().damageReduction = 1;
            Define<TagArmor>().blockage = 0;
            Define<TagPrice>().price = 5;
            Define<TagTier>().tier = 1;
            Define<TagEquipableBy>().classes.Add(typeof(Healer));
        }
    }

    public class PlateBracers : BaseArmorEntity
    {
        public PlateBracers()
        {
            Define<TagItemName>().name = "Plate Bracers";
            Define<TagArmor>().health = 14;
            Define<TagArmor>().evasion = 0;
            Define<TagArmor>().damageReduction = 0;
            Define<TagArmor>().blockage = 0;
            Define<TagPrice>().price = 30;
            Define<TagTier>().tier = 2;
            Define<TagEquipableBy>().classes.Add(typeof(Healer));
        }
    }

    public class BandedRobe : BaseArmorEntity
    {
        public BandedRobe()
        {
            Define<TagItemName>().name = "Banded Robe";
            Define<TagArmor>().health = 20;
            Define<TagArmor>().evasion = 0.1f;
            Define<TagArmor>().damageReduction = 1;
            Define<TagArmor>().blockage = 0;
            Define<TagPrice>().price = 75;
            Define<TagTier>().tier = 3;
            Define<TagEquipableBy>().classes.Add(typeof(Healer));
        }
    }
}