using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Source.Village
{
    public class SummoningHorn : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public bool canSummon => G.state.canSummonToday;
        public bool isFirstSummon => G.state.isFirstSummon;

        public async void OnPointerClick(PointerEventData eventData)
        {
            if (!canSummon) return;
            
            transform.DOKill();
            transform.DOPunchScale(Vector3.one * 0.2f, 0.3f);
            
            G.state.canSummonToday = false;

            await Camera.main.DOShakePosition(2, 0.05f, 10, 45f);


            if (isFirstSummon)
            {
                G.state.isFirstSummon = false;
                G.main.SummonInitialHeroes();
                return;
            }

            G.main.SummonRecruits();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!canSummon) return;

            transform.DOKill();
            transform.DOScale(Vector3.one * 1.2f, 0.2f).SetEase(Ease.OutBack);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOKill();
            transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.InBack);
        }
    }
}