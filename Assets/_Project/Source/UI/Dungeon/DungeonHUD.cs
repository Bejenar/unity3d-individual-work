using System;
using System.Collections.Generic;
using _Project.Data.Items;
using Engine.Math;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace _Project.Source.Village.UI
{
    public class DungeonHUD : MonoBehaviour
    {
        public Slider healthBarPrefab;
        
        public UnitStatusHUD unitStatusHUDPrefab;

        public PopupText popupTextPrefab;

        public Transform unitStatusHUDContainer;

        public Transform test;

        public void InitHUD(List<DungeonHero> dungeonHeroes)
        {
            foreach (var dungeonHero in dungeonHeroes)
            {
                var unitStatusHUD = Instantiate(unitStatusHUDPrefab, unitStatusHUDContainer);
                dungeonHero.hud = unitStatusHUD;
                unitStatusHUD.Init(dungeonHero);
            }
        }

        int i = 0;
        public void ShowRandomText()
        {
            var methods = new Action<Vector3>[]
            {
                ShowMissText, ShowBlockText, ShowEvadeText, ShowFailedHealText,
                v => ShowDamageText(Random.Range(-20, 20), v, Random.value < 0.5f, Random.value < 0.5f),
                v => ShowMoneyText(Random.Range(1, 40), v)
            };
            
            var randomMethod = methods[(++i % methods.Length)];
            randomMethod(test.position); // You can replace the Vector3 parameter with the desired position
        }

        public void ShowMissText(Vector3 position)
        {
            ShowPopupText("missed".Color(Color.gray), position);
        }

        // blocked, DIM_GRAY color
        public void ShowBlockText(Vector3 position)
        {
            ShowPopupText("blocked".Color(Color.gray), position);
        }

        // evaded, LIGHT_SLATE_GRAY
        public void ShowEvadeText(Vector3 position)
        {
            ShowPopupText("evaded".Color(Color.gray), position);
        }

        // if change < 0
        //     (Color.BROWN if is_hero else Color.CORNSILK);
        // else Color.GREEN_YELLOW;
        // if critical:
        //     Color.DARK_ORANGE;
        public void ShowDamageText(int dmg, Vector3 position, bool isHero, bool isCritical)
        {
            var color = dmg <= 0 ? (isHero ? "#A52A2A" : "#FFF8DC") : "#ADFF2F";
            if (isCritical) color = "#FF8C00";
            ShowPopupText($"{Mathf.Abs(dmg)}".Color(color), position, isCritical);
        }

        public void ShowMoneyText(int heal, Vector3 position)
        {
            ShowPopupText($"+{heal} <sprite=0>".Color("#a47c37"), position);
        }

        // GREEN_YELLOW.darkened(0.2)
        public void ShowFailedHealText(Vector3 position)
        {
            ShowPopupText($"0".Color(Color.black), position);
        }
        
        public readonly Vector3 FloatingTextOffset = new Vector3(0, 220, 0);

        public void ShowPopupText(string text, Vector3 position, bool isCritical = false)
        {
            position = Camera.main.WorldToScreenPoint(position) + FloatingTextOffset;
            var popupText = Instantiate(popupTextPrefab, transform);
            popupText.transform.position = position;
            popupText.SetText(text, isCritical);
        }

        public Slider RegisterHealthBar(DungeonCharacter target, Vector3 offset)
        {
            var healthBar = Instantiate(healthBarPrefab, this.transform);
            healthBar.transform.position = Camera.main.WorldToScreenPoint(target.transform.position + offset);

            healthBar.maxValue = target.unit.MaxHealth;
            healthBar.value = target.unit.Health;

            return healthBar;
        }
    }
}