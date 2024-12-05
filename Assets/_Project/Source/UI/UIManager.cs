using _Project.Data;
using _Project.Data.Items;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityUtils;

namespace _Project.Source.Village.UI
{
    public class UIManager : MonoBehaviour
    {
        public Canvas mainCanvas;
        public SpeechBubble speechBubblePrefab;
        
        public GameObject questBoard;
        public GameObject disableInput;

        public UnitSelector unitSelector;
        public UnitTooltipView tooltipView;
        public RecruitTooltipView recruitTooltipView;
        public UpgradePopup upgradePopup;
        public BaseTooltip goldBalanceView;
        public ExpeditionSummary expeditionSummary;

        private void Awake()
        {
            G.ui = this;
            G.fader.FadeOut();
        }
        
        public void SetActiveAllGameObjects(bool isActive)
        {
            Debug.Log("SetActiveAllGameObjects " + isActive);
            questBoard?.SetActive(isActive);
            unitSelector?.gameObject.SetActive(isActive);
            tooltipView?.gameObject.SetActive(isActive);
            recruitTooltipView?.gameObject.SetActive(isActive);
            upgradePopup?.gameObject.SetActive(isActive);
            goldBalanceView?.gameObject.SetActive(isActive);
            expeditionSummary?.gameObject.SetActive(isActive);
        }

        private async void Start()
        {
            SetActiveAllGameObjects(true);
            await UniTask.WaitForEndOfFrame();
            SetActiveAllGameObjects(false);
            // Func<Hero> newHero = () => new Hero(CMS.GetAll<BaseHeroClass>().GetRandom());
            //
            // var hero = newHero();
            // hero.LevelUp();
            // hero.LevelUp();
            // hero.Weapon = CMS.GetAll<BaseWeaponEntity>().GetRandom();
            // hero.Armor = CMS.GetAll<BaseArmorEntity>().GetRandom();
            // hero.Ring = CMS.GetAll<BaseRingEntity>().GetRandom();
            // hero.UpdateStats();
            // G.state.heroes.Add(hero);
            // G.state.heroes.Add(newHero());
            // G.state.heroes.Add(newHero());

            unitSelector.UpdateView();

            // OpenQuestBoard();
        }

        public void Say(Transform parent, string text, int yOffset = 0)
        {
            var bubble = Instantiate(speechBubblePrefab, mainCanvas.transform);
            bubble.transform.SetSiblingIndex(0);
            bubble.Print(parent, text, yOffset);
        }

        public void Punch(Transform target)
        {
            target.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.2f);
        }

        public void QPunch(Transform target)
        {
            target.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.1f);
        }

        public void ShowGoldBalance()
        {
            goldBalanceView.gameObject.SetActive(true);
        }
        
        public async void ShowUnitPickerAsync()
        {
            unitSelector.UpdateView();
            await ShowWindow(unitSelector.gameObject);
        }

        public async UniTask CloseUnitPicker()
        {
            await CloseWindow(unitSelector.gameObject);
        }

        public async void OpenQuestBoard()
        {
            await ShowWindow(questBoard);
        }

        public async void CloseQuestBoard()
        {
            await CloseWindow(questBoard);
        }

        public async UniTask ShowWindow(GameObject window)
        {
            G.cam?.ToggleInput(false);
            window.transform.localScale = Vector3.zero;
            window.SetActive(true);
            await window.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
        }

        public async UniTask CloseWindow(GameObject window)
        {
            await window.transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InBack)
                .OnComplete(() =>
                {
                    G.cam?.ToggleInput(true);
                    window.SetActive(false);
                });
        }

        public void DisableInput()
        {
            Debug.Log("DisableInput");
            G.cam?.ToggleInput(false);
            disableInput?.SetActive(true);
        }

        public void EnableInput()
        {
            Debug.Log("EnableInput");
            G.cam?.ToggleInput(true);
            disableInput?.SetActive(false);
        }
    }
}