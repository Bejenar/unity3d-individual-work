using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Data.Items
{
    public class DungeonMonster : DungeonCharacter
    {
        public Slider hpSlider;

        public Vector3 offset = new Vector3(0, 1.5f, 0);
        
        public Monster monster
        {
            get => unit as Monster;
            set => unit = value;
        }

        public void Init(Monster monster)
        {
            this.monster = monster;
            hpSlider = G.dungeon.hud.RegisterHealthBar(this, offset);
            UpdateUI();
        }

        public override void UpdateUI()
        {
            hpSlider.value = monster.Health;
        }

        public override UniTask Die()
        {
            Destroy(hpSlider.gameObject);
            return base.Die();
        }
    }
}