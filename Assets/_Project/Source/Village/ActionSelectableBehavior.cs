using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _Project.Source.Village.UI
{
    public class ActionSelectableBehavior : SelectableBehaviour
    {
        public UnityEvent action;
        
        public override void OnPointerClick(PointerEventData eventData)
        {
            action?.Invoke();
        }
    }
}