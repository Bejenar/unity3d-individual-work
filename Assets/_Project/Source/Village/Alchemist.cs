using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Data.Items;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityUtils;
using Random = UnityEngine.Random;

namespace _Project.Source.Village
{
    public class Alchemist : MonoBehaviour
    {
        private readonly int[] upgradeCosts = { 0, 10, 40, 100, 200 };
        private readonly string buildingName = "Alchemist's house";
        private readonly string buildingDescription = "Buy rings";
        private string upgradeName => tier == 0 ? $"Restore {buildingName}" : $"Upgrade {buildingName}";
        
        public List<BaseRingEntity> rings = new List<BaseRingEntity>();

        public int tier = 0;

        public void Start()
        {
            tier = G.state.alchemistTier;
            rings =  CMS.GetAll<BaseRingEntity>();
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
            G.state.alchemistTier = tier;
            G.ui.upgradePopup.Hide();

            await transform.DOPunchScale(Vector3.zero.With(y: 0.5f), 0.5f, 10, 1).SetEase(Ease.InOutBack);
        }
        
        public int GetNextUpgradeCost()
        {
            return upgradeCosts[tier + 1];
        }
        
        public BaseRingEntity GetUpgradeCanAfford(Hero hero)
        {
            var currentEquipment = hero.Ring;

            var availableEquip = rings
                .Where(w => w.Get<TagTier>().tier <= tier).ToList();
            
            var affordableEquip = availableEquip
                .Where(w => w.Get<TagPrice>().price <= hero.Gold)
                .OrderByDescending(w => w.Get<TagPrice>().price)
                .FirstOrDefault();

            if (currentEquipment == null)
            {
                return affordableEquip;
            }
            
            if (affordableEquip != null && currentEquipment.Get<TagItemName>().name != affordableEquip.Get<TagItemName>().name)
            {
                return affordableEquip;
            }
            
            return null;
        }
    }
}