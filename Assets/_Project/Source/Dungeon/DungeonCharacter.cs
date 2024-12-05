using System.Threading;
using _Project.Data.Traits;
using _Project.Source.Dungeon.Battle;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Project.Data.Items
{
    public abstract class DungeonCharacter : MonoBehaviour
    {
        public static readonly int MagicAttack = Animator.StringToHash("Magic Attack");
        // public static readonly int TankAttack = Animator.StringToHash("Tank Attack");
        // public static readonly int SwordAttack = Animator.StringToHash("Sword Attack");
        public static readonly int Attack = Animator.StringToHash("Attack");

        public static readonly int Death = Animator.StringToHash("Death");
        public static readonly int Running = Animator.StringToHash("Running");

        public static readonly int DrawWeaponHash = Animator.StringToHash("DrawWeapon");
        public static readonly int HasShieldHash = Animator.StringToHash("hasShield");

        public Animator animator;

        public Unit unit;
        public bool fleeing;
        public int attacksPerformed;

        private Renderer[] _renderers;

        private void Awake()
        {
            _renderers = GetComponentsInChildren<Renderer>();
        }

        public abstract void UpdateUI();

        public bool IsParticipating()
        {
            return unit.Health > 0 && !fleeing;
        }

        public CancellationTokenSource _ct;

        public void TokenCancel()
        {
            _ct.Cancel();
        }

        public CancellationToken AttackAnimation()
        {
            animator.SetTrigger(Attack);
            _ct = new CancellationTokenSource();
            return _ct.Token;
        }

        public CancellationToken MagicAnimation()
        {
            animator.CrossFade(MagicAttack, 0.1f);
            _ct = new CancellationTokenSource();
            return _ct.Token;
        }


        public virtual async UniTask ChangeMorale(int amount)
        {
            await UniTask.CompletedTask;
        }

        public virtual async UniTask AfterMoraleHit()
        {
            await UniTask.CompletedTask;
        }

        public async UniTask TakeDamage(float dmg)
        {
            unit.Health -= dmg;

            var all = G.interactor.FindAll<IAfterHealthChange>();
            foreach (var afterHealthChange in all)
            {
                await afterHealthChange.AfterHealthChange(this, -dmg);
            }
            
            await UniTask.WhenAll(
                _renderers.Select(async r =>
                {
                    var mat = r.material;
                    await mat.DOFloat(1, "_Damage", 0.1f)
                        .SetEase(Ease.OutQuart);
                    await mat.DOFloat(0, "_Damage", 0.1f)
                        .SetEase(Ease.InQuart);
                }));

            if (unit.Health <= 0)
            {
                unit.Health = 0;
                UpdateUI();
                await Die();
                return;
            }

            UpdateUI();
        }

        public async UniTask Heal(float amount)
        {
            unit.Health = Mathf.Min(unit.Health + amount, unit.MaxHealth);
            var all = G.interactor.FindAll<IAfterHealthChange>();
            foreach (var afterHealthChange in all)
            {
                await afterHealthChange.AfterHealthChange(this, amount);
            }

            UpdateUI();
            await UniTask.WaitForSeconds(1);
        }

        public virtual async UniTask Flee()
        {
            Debug.Log("Fleeing");
            fleeing = true;
            await UniTask.WaitForSeconds(2);
            gameObject.SetActive(false);
        }

        public virtual async UniTask Die()
        {
            UpdateUI();
            animator.CrossFade(Death, 0.1f);
            await UniTask.WaitForSeconds(1.5f);
            gameObject.SetActive(false);
        }
    }
}