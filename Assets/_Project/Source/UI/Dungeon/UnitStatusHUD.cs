using _Project.Data;
using _Project.Data.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Source.Village.UI
{
    public class UnitStatusHUD : MonoBehaviour
    {
        public DungeonHero dungeonHero;
        public Hero hero;

        public Image portrait;
        public Image classIcon;
        public TMP_Text unitName;
        
        public Slider hpSlider;
        public Slider moraleSlider;

        public Image mask;

        public void Init(DungeonHero dh)
        {
            this.dungeonHero = dh;
            this.hero = dh.hero;
            UpdateView();
        }

        public void UpdateView()
        {
            mask.gameObject.SetActive(!dungeonHero.IsParticipating());
            hpSlider.gameObject.SetActive(dungeonHero.IsParticipating());
            moraleSlider.gameObject.SetActive(dungeonHero.IsParticipating());
            
            hpSlider.maxValue = hero.MaxHealth;
            moraleSlider.maxValue = hero.MaxMorale;
            
            hpSlider.value = hero.Health;
            moraleSlider.value = hero.Morale;
            
            unitName.text = hero.name;
            classIcon.sprite = hero.model.Get<TagClass>().icon;
        }
    }
}