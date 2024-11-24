using UnityEngine;

namespace _Project.Data.Items
{
    public abstract class BaseRingEntity : CMSEntity
    {
        public BaseRingEntity()
        {
            Define<TagItemName>();
            Define<TagTier>();
            Define<TagPrice>();
            Define<TagStatsBuff>();
            Define<TagEquipableBy>();
        }
    }

    public class RingOfPower : BaseRingEntity
    {
        public RingOfPower()
        {
            Define<TagItemName>().name = "Ring of Power";
            Define<TagStatsBuff>().damage = new Vector2Int(1, 1);
            Define<TagPrice>().price = 20;
            Define<TagTier>().tier = 1;
        }
    }

    public class RingOfVigor : BaseRingEntity
    {
        public RingOfVigor()
        {
            Define<TagItemName>().name = "Ring of Vigor";
            Define<TagStatsBuff>().health = 15;
            Define<TagPrice>().price = 20;
            Define<TagTier>().tier = 1;
        }
    }

    public class RingOfRegeneration : BaseRingEntity
    {
        public RingOfRegeneration()
        {
            Define<TagItemName>().name = "Ring of Regeneration";
            Define<TagStatsBuff>().healthRegen = 1;
            Define<TagPrice>().price = 20;
            Define<TagTier>().tier = 1;
        }
    }

    public class RingOfVulnerability : BaseRingEntity
    {
        public RingOfVulnerability()
        {
            Define<TagItemName>().name = "Ring of Vulnerability";
            Define<TagStatsBuff>().critChance = 0.2f;
            Define<TagPrice>().price = 20;
            Define<TagTier>().tier = 1;
        }
    }

    public class RingOfEvasion : BaseRingEntity
    {
        public RingOfEvasion()
        {
            Define<TagItemName>().name = "Ring of Evasion";
            Define<TagStatsBuff>().evasion = 0.2f;
            Define<TagPrice>().price = 20;
            Define<TagTier>().tier = 1;
        }
    }

    public class RingOfAccuracy : BaseRingEntity
    {
        public RingOfAccuracy()
        {
            Define<TagItemName>().name = "Ring of Accuracy";
            Define<TagStatsBuff>().hitChance = 0.2f;
            Define<TagPrice>().price = 20;
            Define<TagTier>().tier = 1;
        }
    }

    public class RingOfProtection : BaseRingEntity
    {
        public RingOfProtection()
        {
            Define<TagItemName>().name = "Ring of Protection";
            Define<TagStatsBuff>().damageReduction = 2;
            Define<TagPrice>().price = 20;
            Define<TagTier>().tier = 1;
        }
    }

    public class TheGuardiansRing : BaseRingEntity
    {
        public TheGuardiansRing()
        {
            Define<TagItemName>().name = "The Guardians Ring";
            Define<TagStatsBuff>().blockage = 0.2f;
            Define<TagPrice>().price = 20;
            Define<TagTier>().tier = 1;
        }
    }

    public class TheOneRing : BaseRingEntity
    {
        public TheOneRing()
        {
            Define<TagItemName>().name = "The One Ring";
            Define<TagStatsBuff>().health = 100;
            Define<TagPrice>().price = 1000;
            Define<TagTier>().tier = 3;
        }
    }
}