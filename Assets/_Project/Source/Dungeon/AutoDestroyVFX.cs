using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.VFX;

namespace _Project.Source.Dungeon.Battle
{
    public class AutoDestroyVFX : MonoBehaviour
    {
        [SerializeField]
        public float duration;

        public VisualEffect visualEffect;

        private async void Start()
        {
            visualEffect = GetComponent<VisualEffect>();
            if (visualEffect != null)
            {
                await UniTask.WaitForSeconds(duration * 2 + 3);
                Destroy(gameObject);
            }
        }
    }
}