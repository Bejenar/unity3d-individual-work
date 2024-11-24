using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Project.Source.Village.UI
{
    public class RecruitTooltipView : UnitTooltipView
    {
        public Button recruitButton;
        [FormerlySerializedAs("hero")]
        public VillageHero villageHero;
        
        public override void UpdateView(Hero hero)
        {
            base.UpdateView(hero);
            nameText.text = $"{hero.name} (Recruit)";
            recruitButton.enabled = G.main.CanRecruit();
        }

        public void ShowTooltip(VillageHero vh, Vector3 position)
        {
            base.ShowTooltip(vh.hero, position);
            villageHero = vh;
        }

        public void Recruit()
        {
            G.main.RecruitHero(villageHero);
            Hide();
        }
    }
}