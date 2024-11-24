using System;
using _Project.Data;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Source.Village.UI
{
    public class UnitPlateSmall : MonoBehaviour, IPointerClickHandler
    {
        public Hero hero;

        public Image portrait;
        public Image classIcon;
        public TMP_Text unitName;

        public void Init(Hero hero)
        {
            this.hero = hero;
            UpdateView();
        }

        public void UpdateView()
        {
            unitName.text = hero.name;
            classIcon.sprite = hero.model.Get<TagClass>().icon;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            G.ui.unitSelector.DeselectUnit(this);
        }
    }
}