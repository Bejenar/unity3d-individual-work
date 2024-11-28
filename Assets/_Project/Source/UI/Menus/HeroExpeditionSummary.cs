using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Project.Source.Village.UI
{
    public class HeroExpeditionSummary : MonoBehaviour
    {
        [FormerlySerializedAs("name")]
        public TMP_Text nameLabel;

        public TMP_Text description;
        public TMP_Text level;
        public TMP_Text remainingXp;
        public Slider xpSlider;
        public TMP_Text goldLabel;
        public Image avatar;
        public GameObject diedMask;

        private Hero hero;

        private int oldLevel;
        private int gold;
        private int oldExperience;

        public void Init(Hero hero)
        {
            this.hero = hero;
            oldLevel = hero.Level;
            gold = hero.Gold;
            oldExperience = hero.Experience;
            diedMask.gameObject.SetActive(false);
            UpdateView();
        }

        public void UpdateView()
        {
            nameLabel.text = hero.name;
            description.text = GetDescription();
            level.text = $"Level {hero.Level + 1}";
            remainingXp.gameObject.SetActive(false);
            xpSlider.value = (float)(hero.Experience - hero.EXPERIENCE_LEVELS[hero.Level]) /
                             (hero.EXPERIENCE_LEVELS[oldLevel + 1] - hero.EXPERIENCE_LEVELS[oldLevel]);
            goldLabel.text = $"{gold} <sprite=0>";
            
            TweenSummary();
        }

        public async void TweenSummary()
        {
            if (hero.died)
            {
                diedMask.gameObject.SetActive(true);
                diedMask.transform.localScale = Vector3.one * 2;
                diedMask.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.InOutQuad);
            }
            
            hero.OnDungeonClear(); // TODO should probably be called from somewhere else
            
            await TweenGold();
            await TweenRankProgression();

            
        }

        public async UniTask TweenGold()
        {
            await DOTween.To(() => gold, x => goldLabel.text = $"{x} <sprite=0>", hero.Gold, 1f);
        }

        public async UniTask TweenRankProgression()
        {
            Debug.Log($"old level {oldLevel} new level {hero.Level}");
            int rankUps = hero.Level - oldLevel;

            if (rankUps > 0)
            {
                for (int i = 0; i < rankUps; i++)
                {
                    await TweenXP(oldExperience,
                        hero.EXPERIENCE_LEVELS[oldLevel + 1],
                        hero.EXPERIENCE_LEVELS[oldLevel + 1]);
                    oldLevel++;
                    level.text = $"Level {oldLevel + 1}";
                    level.transform.DOShakeScale(0.2f, 0.2f);
                    oldExperience = 0;
                }
            }

            await TweenXP(oldExperience,
                hero.Experience - hero.EXPERIENCE_LEVELS[hero.Level],
                hero.EXPERIENCE_LEVELS[oldLevel + 1] - hero.EXPERIENCE_LEVELS[oldLevel]);

            remainingXp.gameObject.SetActive(true);
            int remaining = hero.EXPERIENCE_LEVELS[hero.Level + 1] - hero.Experience;
            remainingXp.text = $"Remaining {remaining}";
            remainingXp.transform.localScale = Vector3.zero;
            await remainingXp.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.InOutQuad);
            await DOTween.To(() => 0, x => remainingXp.text = $"Remaining {x}", remaining, 1f).SetEase(Ease.OutQuart);
        }

        public async UniTask TweenXP(float startXP, float endXP, float max)
        {
            xpSlider.value = startXP / max;
            await xpSlider.DOValue(endXP / max, 1).SetEase(Ease.OutQuad);
        }


        private string GetDescription()
        {
            return hero.fled ? "Fled" : hero.died ? "Died" : "Cleared the dungeon";
        }
    }
}