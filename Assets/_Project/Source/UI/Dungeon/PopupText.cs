using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Project.Source.Village.UI
{
    public class PopupText : MonoBehaviour
    {
        private bool isCritical;

        public void Start()
        {
            TMP_Text label = GetComponent<TMP_Text>();
            Vector3 position = transform.position;
            // Color modulate = label.color;
            // Vector3 scale = isCritical ? new Vector3(7.0f, 10.0f, 1.0f) : new Vector3(3.0f, 3.0f, 1.0f);
            float targetRotation = isCritical ? Random.Range(-2.3f, 2.3f) : Random.Range(-0.3f, 0.3f);

            transform.rotation = Quaternion.Euler(0, 0, targetRotation);
            Sequence t = DOTween.Sequence()
                .Append(transform.DOMoveY(position.y + Random.Range(-35, -55), 1f).SetEase(Ease.OutElastic))
                .Join(transform.DOMoveX(position.x + Random.Range(-25, 25), 1f).SetEase(Ease.OutExpo))
                .Append(label.DOColor(new Color(1.0f, 1.0f, 1.0f, 0.0f), 0.4f).SetDelay(0.3f));

            if (isCritical)
            {
                t.Insert(0, transform.DOScale(Vector3.one * 1.5f, 0.6f).SetEase(Ease.OutElastic))
                    .Append(transform.DOScale(Vector3.one, 0.6f).SetEase(Ease.OutCirc).SetDelay(0.6f))
                    .Join(transform.DORotate(new Vector3(0, 0, -targetRotation * 0.5f), 0.3f).SetEase(Ease.OutCirc))
                    .Append(transform.DORotate(new Vector3(0, 0, targetRotation * 0.2f), 0.3f).SetEase(Ease.OutCirc)
                        .SetDelay(0.3f))
                    .Append(transform.DORotate(Vector3.zero, 1.0f).SetEase(Ease.OutCirc).SetDelay(0.6f));
            }
            else
            {
                t.Insert(0, transform.DOScale(Vector3.one, 1.0f).SetEase(Ease.OutElastic))
                    .Join(transform.DORotate(Vector3.zero, 2.0f).SetEase(Ease.OutElastic));
            }

            t.OnComplete(() =>
            {
                t.Kill();
                Destroy(gameObject);
            });
        }

        public void SetText(string text, bool isCritical = false)
        {
            this.isCritical = isCritical;
            GetComponent<TMP_Text>().text = text;
        }
    }
}