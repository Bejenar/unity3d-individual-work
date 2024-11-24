using System;
using _Project.Data.Items;
using _Project.Source;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

[BlackboardEnum]
public enum ItemType
{
    WEAPON,
    ARMOR,
    RING
}

[Serializable, GeneratePropertyBag]
[Condition(name: "CanBuy", story: "[Hero] can buy [Item]", category: "Conditions",
    id: "9ba16ad08ea90286ef8568d4a3ff146e")]
public partial class CanBuyCondition : Condition
{
    [SerializeReference]
    public BlackboardVariable<ItemType> Item;

    [SerializeReference]
    public BlackboardVariable<VillageHero> Hero;

    public override bool IsTrue()
    {
        var blacksmith = G.main.blacksmith;
        var alchemist = G.main.alchemist;
        CMSEntity upgrade;
        
        switch (Item.Value)
        {
            case ItemType.WEAPON when blacksmith.tier > 0:
                upgrade = blacksmith.GetWeaponUpgrade(Hero.Value.hero);
                break;

            case ItemType.ARMOR when blacksmith.tier > 0:
                upgrade = blacksmith.GetArmorUpgrade(Hero.Value.hero);
                break;

            case ItemType.RING when alchemist.tier > 0:
                upgrade = alchemist.GetUpgradeCanAfford(Hero.Value.hero);
                break;

            default:
                return false;
        }

        if (upgrade == null)
        {
            return false;
        }

        Debug.Log("Can buy " + upgrade.Get<TagItemName>().name);
        return true;
    }
}