using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class RotateObject : MonoBehaviour
    {
        public Quaternion finishRotate;

        public void StartRotate(float time)
        {
            StartCoroutine(Rotate(time));
        }
        
        private IEnumerator Rotate(float time)
        {
            var startRotation = transform.rotation;
            var beginTime = time;
            
            while (time > 0)
            {
                transform.rotation = Quaternion.Lerp(startRotation, finishRotate, 1 - (time/beginTime));
                
                time -= Time.fixedDeltaTime;

                yield return new WaitForFixedUpdate();
            }
        }
    }
}