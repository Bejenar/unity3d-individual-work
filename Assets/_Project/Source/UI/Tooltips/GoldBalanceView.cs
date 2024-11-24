using TMPro;
using UnityEngine;

namespace _Project.Source.Village.UI
{
    public class GoldBalanceView : BaseTooltip 
    {
        public TMP_Text goldText;
        
        private void OnEnable()
        {
            goldText.text = $"{G.state.gold} Gold";
            CalculateAnchor(Input.mousePosition);
        }
    }
}