using System;
using _Project.Data.Items;
using Cysharp.Threading.Tasks;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace _Project.Source.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Purchase Upgrade", story: "[Agent] is purchasing [equipment_type] upgrade",
        category: "Action", id: "purchase_action")]
    public class PurchaseUpgradeAction : VillagerAction
    {
        [SerializeReference]
        public BlackboardVariable<ItemType> equipment_type;

        protected override Status OnStart()
        {
            base.OnStart();

            Purchase().Forget();

            return Status.Running;
        }

        private async UniTask Purchase()
        {
            Debug.Log("Purchasing upgrade " + equipment_type.Value);
            await UniTask.Delay(1000);

            switch (equipment_type.Value)
            {
                case ItemType.WEAPON:
                    PurchaseUpgrade(G.main.blacksmith.GetWeaponUpgrade(Agent.Value.hero), (h, e) => h.Weapon = e);
                    break;

                case ItemType.ARMOR:
                    PurchaseUpgrade(G.main.blacksmith.GetArmorUpgrade(Agent.Value.hero), (h, e) => h.Armor = e);
                    break;

                case ItemType.RING:
                    PurchaseUpgrade(G.main.alchemist.GetUpgradeCanAfford(Agent.Value.hero), (h, e) => h.Ring = e);
                    break;
            }

            status = Status.Success;
        }

        private void PurchaseUpgrade<T>(T upgrade, Action<Hero, T> setUpgrade) where T : CMSEntity
        {
            var h = hero.hero;
            var price = upgrade.Get<TagPrice>().price;
            h.Gold -= price;
            G.state.gold += Mathf.CeilToInt(price * 0.1f);
            setUpgrade(h, upgrade);
            h.UpdateStats();
        }
    }
}