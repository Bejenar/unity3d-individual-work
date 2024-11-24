using _Project.Data;
using _Project.Data.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Source.Village.UI
{
    public class UnitTooltipView : BaseTooltip
    {
        public Slider xpSlider;
        public TMP_Text xpText;
        
        public TMP_Text nameText;
        public TMP_Text healthText;
        public TMP_Text healthRegenText;
        public TMP_Text armorText;
        public TMP_Text guardText;
        public TMP_Text evasionText;
        public TMP_Text powerText;
        public TMP_Text critChanceText;
        public TMP_Text hitChanceText;
        public TMP_Text goldText;
        public Image classIcon;

        public GameObject weaponText;
        public GameObject armorItemText;
        public GameObject ringText;

        public GameObject tint;

        private bool showSponsor;
        public GameObject sponsorPanel;
        public Slider sponsorSlider;
        public Button sponsorButton;
        public TMP_Text sponsorValue;

        private Hero hero;

        public override void Awake()
        {
            base.Awake();
            tint.SetActive(false);
        }

        public virtual void UpdateView(Hero hero)
        {
            this.hero = hero;
            nameText.text = $"{hero.name}";
            xpSlider.value = (float)(hero.Experience - hero.EXPERIENCE_LEVELS[hero.Level]) /
                             (hero.EXPERIENCE_LEVELS[hero.Level + 1] - hero.EXPERIENCE_LEVELS[hero.Level]);
            xpText.text = $"lvl {hero.Level + 1}";
            healthText.text = $"Health: {hero.Health:F0}";
            healthRegenText.text = $"Health Regen: {hero.HealthRegeneration}";
            armorText.text = $"Armor: {hero.DamageReduction:F0}";
            guardText.text = $"Guard: {hero.Blockage:P0}";
            evasionText.text = $"Evasion: {hero.Evasion:P0}";
            powerText.text = $"Power: {hero.DamageRange.x:F0} - {hero.DamageRange.y:F0}";
            critChanceText.text = $"Crit Chance: {hero.CritChance:P0}";
            hitChanceText.text = $"Hit Chance: {hero.HitChance:P0}";
            goldText.text = $"Gold: {hero.Gold}";
            classIcon.sprite = hero.model.Get<TagClass>().icon;


            weaponText.SetActive(false);
            armorItemText.SetActive(false);
            ringText.SetActive(false);
            if (hero.Weapon != null)
            {
                weaponText.GetComponentInChildren<TMP_Text>().text = $"{hero.Weapon.Get<TagItemName>().name}";
                weaponText.SetActive(true);
            }

            if (hero.Armor != null)
            {
                armorItemText.GetComponentInChildren<TMP_Text>().text = $"{hero.Armor.Get<TagItemName>().name}";
                armorItemText.SetActive(true);
            }

            if (hero.Ring != null)
            {
                ringText.GetComponentInChildren<TMP_Text>().text = $"{hero.Ring.Get<TagItemName>().name}";
                ringText.SetActive(true);
            }


            if (sponsorSlider != null)
            {
                sponsorPanel.SetActive(showSponsor);
                if (!showSponsor) return;

                sponsorSlider.onValueChanged.RemoveAllListeners();
                sponsorSlider.onValueChanged.AddListener(UpdateSponsorLabel);

                sponsorSlider.value = 0;
                sponsorValue.text = "0";
                sponsorSlider.maxValue = G.state.gold;
                sponsorButton.interactable = G.state.gold > 0;
            }
        }

        public void Sponsor()
        {
            G.main.Sponsor(hero, (int)sponsorSlider.value);
            Hide();
        }

        public void UpdateSponsorLabel(float value)
        {
            sponsorValue.text = $"{(int)value}";
        }

        public virtual void ShowTooltip(Hero hero, Vector3 position, bool showSponsor = false)
        {
            gameObject.SetActive(true);
            tint.SetActive(true);
            
            this.showSponsor = showSponsor;
            Debug.Log("Show tooltip");
            UpdateView(hero);

            // Calculate anchor and pivot based on mouse position
            CalculateAnchor(position);

            gameObject.transform.position = position;
        }

        public override void Hide()
        {
            // if (hovering) return;
            Debug.Log("Hide tooltip");
            tint.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}