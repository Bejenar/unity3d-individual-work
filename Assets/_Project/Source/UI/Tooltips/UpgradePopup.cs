using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Source.Village.UI
{
    public class UpgradePopup : BaseTooltip
    {
        public TMP_Text upgradeName;
        public TMP_Text upgradeDescription;
        public TMP_Text upgradeCost;
        public Button upgradeButton;
        
        public void UpdateView(string name, string description, int cost, Action action)
        {
            upgradeName.text = name;
            upgradeDescription.text = description;
            upgradeCost.text = $"{cost} Gold";
            
            upgradeButton.onClick.RemoveAllListeners();
            upgradeButton.onClick.AddListener(() => action());
            upgradeButton.interactable = cost <= G.state.gold;
        }
        
        public void Show(Vector3 position)
        {
            gameObject.SetActive(true);
            CalculateAnchor(position);
            gameObject.transform.position = position;
        }
    }
}