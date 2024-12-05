using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityUtils;

namespace _Project.Source.Village.UI
{
    public class SpeechBubble : MonoBehaviour
    {
        public TMP_Text contentSizeControllerText;
        public TMP_Text text;

        public CanvasGroup canvasGroup;
        
        public Transform parent;
        public float yOffset;
        
        private async void Start()
        {
            contentSizeControllerText.text = "";
            text.text = "";
        }

        private void Update()
        {
            Vector3 position = Camera.main.WorldToScreenPoint(parent.position).Add(y:yOffset);
            transform.position = position;
        }

        public async void Print(Transform parent, string actionDefinition, float yOffset = 0)
        {
            this.parent = parent;
            this.yOffset = yOffset;
            
            Print(contentSizeControllerText, actionDefinition).Forget();
            await Print(text, actionDefinition);
            
            await UniTask.Delay(TimeSpan.FromSeconds(4));
            
            await canvasGroup.DOFade(0, 2f);
            Destroy(gameObject);
        }
        
        public static async UniTask Print(TMP_Text text, string actionDefinition, string fx = "wave")
        {
            var visibleLength = TextUtils.GetVisibleLength(actionDefinition);
            if (visibleLength == 0) return;

            for (var i = 0; i < visibleLength; i++)
            {
                text.text = $"<link={fx}>{TextUtils.CutSmart(actionDefinition, 1 + i)}</link>";
                await UniTask.WaitForEndOfFrame();
            }
        }
    }
}