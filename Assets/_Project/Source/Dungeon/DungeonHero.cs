using _Project.Source;
using _Project.Source.Dungeon.Battle;
using _Project.Source.Scenes;
using _Project.Source.Village.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Data.Items
{
    public class DungeonHero : DungeonCharacter
    {
        public float drawAnimLength = 0.1f;
        public float sheatheAnimLength = 0.8f;
        public UnitStatusHUD hud;

        public Transform weaponHandSlot;
        public Transform weaponLeftHandSlot;
        public Transform weaponBackSlot;

        [SerializeField]
        private bool hasShield;

        public Hero hero
        {
            get => unit as Hero;
            set => unit = value;
        }

        private void Start()
        {
            if (hero != null)
            {
                animator.SetBool(HasShieldHash, hero.model is Tank);
            }
            else
            {
                animator.SetBool(HasShieldHash, hasShield);
            }
        }

        public void Init(Hero hero)
        {
            this.unit = hero;
            
            foreach (var r in GetComponentsInChildren<Renderer>())
            {
                if (r.material.name.Contains(StaticData.HairMatName))
                {
                    var material = r.material;
                    material.SetColor(StaticData.Tint, hero.hairColor);
                    material.SetFloat(StaticData.TintValue, 1);
                    material.SetColor(StaticData.DarkColor, hero.hairColor); // todo remove
                    material.SetColor(StaticData.LitColor, hero.hairColor);
                }
            }
        }

        public override void UpdateUI()
        {
            hud.UpdateView();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                DrawWeapon();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                SheatheWeapon();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                MagicAnimation();
            } 
            else if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                AttackAnimation();
            }
        }
        
        public async void DrawWeapon()
        {
            animator.SetBool(DungeonCharacter.DrawWeaponHash, true);

            if (hasShield) return;

            await UniTask.WaitForSeconds(drawAnimLength);
            weaponBackSlot.gameObject.SetActive(false);
            weaponHandSlot.gameObject.SetActive(true);
        }

        public async void SheatheWeapon()
        {
            animator.SetBool(DungeonCharacter.DrawWeaponHash, false);

            if (hasShield) return;

            await UniTask.WaitForSeconds(sheatheAnimLength);
            weaponBackSlot.gameObject.SetActive(true);
            weaponHandSlot.gameObject.SetActive(false);
        }

        public override async UniTask ChangeMorale(int amount)
        {
            Debug.Log("Morale change: " + amount);
            var onMoraleHitList = G.interactor.FindAll<IOnMoraleHit>();
            foreach (var interaction in onMoraleHitList)
            {
                await interaction.OnMoraleHit(this, amount);
                UpdateUI();
            }
            
            foreach (var interaction in G.interactor.FindAll<IAfterMoraleHit>())
            {
                await interaction.AfterMoraleHit(G.dungeon.fieldData, this);
                UpdateUI();
            }
        }

        // public override async UniTask AfterMoraleHit()
        // {
        //     Debug.Log("After morale hit from " + unit.model.Get<TagClass>().loc);
        //     Debug.Log("Is participating: " + IsParticipating());
        //     Debug.Log($"Hp and morale: {hero.Health} {hero.Morale}");
        //     
        //     if (!IsParticipating()) return;
        //     
        //     var afterMoraleHitList = G.interactor.FindAll<IAfterMoraleHit>();
        //     foreach (var interaction in afterMoraleHitList)
        //     {
        //         await interaction.AfterMoraleHit(G.dungeon.fieldData, this);
        //     }
        //     UpdateUI();
        // }

        public override async UniTask Die()
        {
            hero.died = true;
            UpdateUI();
            animator.CrossFade(Death, 0.1f);
            G.dungeon.fieldData.OnHeroDied(this);
            await UniTask.WaitForSeconds(1f);
        }

        public void AddGold(int goldPerHero)
        {
            hero.AddGold(goldPerHero);
        }

        public override UniTask Flee()
        {
            hero.fled = true;
            transform.Rotate(0, 180, 0);
            animator.CrossFade(Running, 0.1f);
            return base.Flee();
        }
    }
}