using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class Punch : MonoBehaviour
    {
        private void OnEnable()
        {
            StartCoroutine(PunchDelay());
        }

        private IEnumerator PunchDelay()
        {
            yield return new WaitForSeconds(0.1f);
            
            gameObject.SetActive(false);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out PunchFeedback punchFeedback))
            {
                punchFeedback.action?.Invoke();
                gameObject.SetActive(false);
            }
            Debug.Log(other.name);
        }
    }
}