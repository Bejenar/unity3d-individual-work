using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Source.Village
{
    public abstract class SelectableBehaviour : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private static readonly int SelectValue = Shader.PropertyToID("_SelectValue");
        
        protected Renderer[] renderers;
        
        public virtual void Awake()
        {
            renderers = GetComponentsInChildren<Renderer>();
        }
        
        public virtual void Start()
        {
            renderers = GetComponentsInChildren<Renderer>();
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            foreach (var meshRenderer in renderers)
            {
                var material = meshRenderer.material; // Use the local material
                material.SetFloat(SelectValue, 0.5f);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            foreach (var r in renderers)
            {
                var material = r.material; // Use the local material
                material.SetFloat(SelectValue, 0.0f);
            }
        }

        public abstract void OnPointerClick(PointerEventData eventData);
    }
}