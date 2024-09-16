using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class RaycastFeedback : MonoBehaviour
    {
        public UnityEvent action;
        public string textTooltip;

        private void OnEnable()
        {
            
        }
    }
}