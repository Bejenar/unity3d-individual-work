using UnityEngine;
using UnityEngine.UI;

namespace _Project.Source.Village
{
    public class Cursor : MonoBehaviour
    {
        public Sprite up;
        public Sprite dn;
        public Image img;
        
        private RectTransform rectTransform;
        
        private void Awake()
        {
            rectTransform = gameObject.GetComponent<RectTransform>();
        }
    
        void Update()
        {
            img.sprite = Input.GetMouseButton(0) ? dn : up;
            rectTransform.position = Input.mousePosition;
        }
    }
}