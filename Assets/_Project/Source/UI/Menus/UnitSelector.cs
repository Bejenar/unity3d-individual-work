using System.Collections.Generic;
using System.Linq;
using _Project.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityUtils;

namespace _Project.Source.Village.UI
{
    public class UnitSelector : MonoBehaviour
    {
        public UnitPlate unitPlatePrefab;
        public UnitPlateSmall unitPlateSmallPrefab;
        public Transform content;
        public Transform selectContent;

        public List<UnitPlate> unitPlates = new List<UnitPlate>();

        public List<UnitPlateSmall> selectedUnits = new List<UnitPlateSmall>();

        private void Awake()
        {
            content.DestroyChildren();
            selectContent.DestroyChildren();
            gameObject.SetActive(false);
        }

        public bool CanSelectUnits()
        {
            return selectedUnits.Count < G.state.maxUnits;
        }

        public void UpdateView()
        {
            foreach (var unitPlate in unitPlates)
            {
                Destroy(unitPlate.gameObject);
            }

            foreach (var selectedUnit in selectedUnits)
            {
                Destroy(selectedUnit.gameObject);
            }

            selectedUnits.Clear();
            unitPlates.Clear();

            foreach (var hero in OrderUnits())
            {
                var unitPlate = Instantiate(unitPlatePrefab, content);
                unitPlate.Init(hero);
                unitPlates.Add(unitPlate);
            }
        }

        public List<Hero> OrderUnits()
        {
            return G.state.heroes.OrderByDescending(hero => hero.Level).ToList();
        }

        public void SelectUnit(UnitPlate unitPlate)
        {
            var unitPlateSmall = Instantiate(unitPlateSmallPrefab, selectContent);
            unitPlateSmall.Init(unitPlate.hero);
            selectedUnits.Add(unitPlateSmall);
            UpdateSelectedUnits();
        }

        public void DeselectUnit(UnitPlate unitPlate)
        {
            var unitPlateSmall = selectedUnits.FirstOrDefault(unit => unit.hero.Id == unitPlate.hero.Id);
            if (unitPlateSmall != null)
            {
                selectedUnits.Remove(unitPlateSmall);
                Destroy(unitPlateSmall.gameObject);
            }
        }

        public void DeselectUnit(UnitPlateSmall unitPlateSmall)
        {
            var unitPlate = unitPlates.FirstOrDefault(unit => unit.hero.Id == unitPlateSmall.hero.Id);
            unitPlate?.Select();
            selectedUnits.Remove(unitPlateSmall);
            Destroy(unitPlateSmall.gameObject);
            UpdateSelectedUnits();
        }

        public void UpdateSelectedUnits()
        {
            selectedUnits = selectedUnits.OrderBy(unit => unit.hero.model.Get<TagClass>().line).ToList();
            for (int i = 0; i < selectedUnits.Count; i++)
            {
                selectedUnits[i].transform.SetSiblingIndex(i);
            }
        }

        public async void ToBattle()
        {
            G.ui.DisableInput();
            G.ui.CloseQuestBoard();
            await CloseAsync();
            await G.main.ToBattle(selectedUnits.Select(unit => unit.hero).ToList());
        }

        public void Close()
        {
            CloseAsync().Forget();
        }

        public async UniTask CloseAsync()
        {
            await transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack);
            gameObject.SetActive(false);
        }
    }
}