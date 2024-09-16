using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class RaycastInteraction : MonoBehaviour
    {
        public TextMeshProUGUI TextUITooltip;
        private RaycastFeedback _raycastFeedback;

        private bool isInteract => Input.GetKeyDown(KeyCode.E); 
        private void Update()
        {
            Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f);
        
            // Create the ray
            Ray ray = Camera.main.ViewportPointToRay(rayOrigin);

            // Perform the raycast
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                foreach (var raycastFeedback in hit.transform.GetComponents<RaycastFeedback>())
                {
                    if (!raycastFeedback.enabled) continue;
                    
                    TextUITooltip.text = raycastFeedback.textTooltip;
                    _raycastFeedback = raycastFeedback;
                    break;
                }
            }

            if (isInteract && _raycastFeedback)
            {
                if(_raycastFeedback.enabled)
                    _raycastFeedback.action?.Invoke();
            }

            if (hit.transform.GetComponents<RaycastFeedback>().Length == 0)
            {
                _raycastFeedback = null;
                TextUITooltip.text = string.Empty;
            }
        }
    }
}