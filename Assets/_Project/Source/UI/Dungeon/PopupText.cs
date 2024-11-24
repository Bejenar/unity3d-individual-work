using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Source.Village.UI
{
    public class PopupText : MonoBehaviour
    {
        private bool isCritical;
        
        public async void Start()
        {
            if (isCritical)
            {
                // PopNumber.gd
                transform.localScale *= 2;
            }

            await transform.DOLocalMoveY(transform.localPosition.y + 50, 1f).SetEase(Ease.InOutQuad);
            Destroy(gameObject);
        }

        public void SetText(string text, bool isCritical = false)
        {
            this.isCritical = isCritical;
            GetComponent<TMP_Text>().text = text;
        }
    }
}