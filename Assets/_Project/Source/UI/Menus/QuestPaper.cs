using _Project.Data.Items;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Source.Village.UI
{
    public class QuestPaper : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public string modelId;
        private CMSEntity model; // TODO LIBRARY support serializable CMSEntity builder

        public Image image;
        public Image lockedOverlay;
        public bool locked;

        private void Start()
        {
            model = CMS.Get<CMSEntity>(modelId);
            Init(model);
        }

        public void Init(CMSEntity model)
        {
            this.model = model;
            image.sprite = model.Get<TagLevelView>().sprite;
            locked = model.Get<TagTier>().tier > G.state.dungeonTier;

            lockedOverlay.gameObject.SetActive(locked);
        }

        public void SelectQuest()
        {
            if (locked) return;

            G.state.selectedDungeon = model;
            G.ui.ShowUnitPickerAsync();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            SelectQuest();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (locked) return;
            transform.DOScale(Vector2.one * 1.1f, 0.1f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(Vector2.one, 0.1f);
        }
    }
}