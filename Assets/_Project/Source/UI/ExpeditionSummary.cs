using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityUtils;

namespace _Project.Source.Village.UI
{
    public class ExpeditionSummary : MonoBehaviour
    {
        public HeroExpeditionSummary heroExpeditionSummaryPrefab;
        public Transform container;
        
        public async void Show()
        {
            gameObject.SetActive(true);
            transform.localScale = Vector3.zero;
            container.DestroyChildren();
            G.state.selectedHeroes.ForEach(h =>
            {
                var heroSummary = Instantiate(heroExpeditionSummaryPrefab, container);
                heroSummary.Init(h);
            });
            
            await transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.InOutBack);
        }
        
        public void Hide()
        {
            transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InOutBack).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
    }
}