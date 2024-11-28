using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Data.Items;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityUtils;
using Input = UnityEngine.Input;

namespace _Project.Source.Village
{
    public class Blacksmith : MonoBehaviour
    {
        private readonly int[] upgradeCosts = { 0, 10, 40, 100, 200 };
        private readonly string buildingName = "Smithy";
        private readonly string buildingDescription = "Get weapons and armor";
        private string upgradeName => tier == 0 ? $"Restore {buildingName}" : $"Upgrade {buildingName}";

        public Dictionary<Type, List<BaseWeaponEntity>> weapons = new Dictionary<Type, List<BaseWeaponEntity>>();
        public Dictionary<Type, List<BaseArmorEntity>> armor = new Dictionary<Type, List<BaseArmorEntity>>();

        public int tier = 0;

        public void Start()
        {
            tier = G.state.smithyTier;
            Init(weapons);
            Init(armor);
        }

        public void Show()
        {
            G.ui.upgradePopup.UpdateView(
                upgradeName,
                buildingDescription,
                GetNextUpgradeCost(),
                Upgrade);
            G.ui.upgradePopup.Show(Input.mousePosition);
        }

        public async void Upgrade()
        {
            G.state.gold -= GetNextUpgradeCost();
            tier++;
            G.state.smithyTier = tier;
            G.ui.upgradePopup.Hide();

            await transform.DOPunchScale(Vector3.zero.With(y: 0.5f), 0.5f, 10, 1).SetEase(Ease.InOutBack);
        }

        public int GetNextUpgradeCost()
        {
            return upgradeCosts[tier + 1];
        }

        public BaseWeaponEntity GetWeaponUpgrade(Hero hero)
        {
            return GetUpgradeCanAfford(hero, weapons);
        }

        public BaseArmorEntity GetArmorUpgrade(Hero hero)
        {
            return GetUpgradeCanAfford(hero, armor);
        }

        public T GetUpgradeCanAfford<T>(Hero hero, Dictionary<Type, List<T>> equipmentMap) where T : CMSEntity
        {
            CMSEntity currentEquipment = typeof(T) == typeof(BaseWeaponEntity) ? hero.Weapon : hero.Armor;

            var availableEquip = equipmentMap[hero.model.GetType()]
                .Where(w => w.Get<TagTier>().tier <= tier).ToList();

            var affordableEquip = availableEquip
                .Where(w => w.Get<TagPrice>().price <= hero.Gold)
                .OrderByDescending(w => w.Get<TagPrice>().price)
                .FirstOrDefault();

            if (currentEquipment == null)
            {
                return affordableEquip;
            }

            if (affordableEquip != null &&
                currentEquipment.Get<TagItemName>().name != affordableEquip.Get<TagItemName>().name)
            {
                return affordableEquip;
            }

            return null;
        }

        public static void Init<T>(Dictionary<Type, List<T>> dict) where T : CMSEntity
        {
            var allItems = CMS.GetAll<T>();
            dict.Clear();

            foreach (var item in allItems)
            {
                if (item.Is<TagEquipableBy>(out var equipableBy))
                {
                    foreach (var heroClass in equipableBy.classes)
                    {
                        if (!dict.ContainsKey(heroClass))
                        {
                            dict[heroClass] = new List<T>();
                        }

                        dict[heroClass].Add(item);
                    }
                }
            }
        }
    }
}