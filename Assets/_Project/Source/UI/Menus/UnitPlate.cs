using _Project.Data;
using DG.Tweening;
using ImprovedTimers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Source.Village.UI
{
    public class UnitPlate : MonoBehaviour, IPointerClickHandler
    {
        public Hero hero;

        public Image portrait;
        public TMP_Text level;
        public TMP_Text unitName;
        public Image classIcon;
        public GameObject check;

        private bool selected = false;


        private void Start()
        {
            selected = false;
            check.SetActive(selected);
        }

        public void Init(Hero hero)
        {
            this.hero = hero;
            UpdateView();
        }

        public void UpdateView()
        {
            unitName.text = hero.name;
            level.text = $"Level {(hero.Level + 1)}";
            classIcon.sprite = hero.model.Get<TagClass>().icon;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (G.ui.unitSelector.CanSelectUnits())
            {
                G.ui.QPunch(transform);
                Select();
                return;
            }

            transform.DOShakePosition(0.1f);
        }

        public void Select()
        {
            selected = !selected;
            check.SetActive(selected);
            if (selected)
                G.ui.unitSelector.SelectUnit(this);
            else
                G.ui.unitSelector.DeselectUnit(this);
        }

        public void ShowTooltip()
        {
            G.ui.tooltipView.ShowTooltip(hero, Input.mousePosition);
        }
    }
}