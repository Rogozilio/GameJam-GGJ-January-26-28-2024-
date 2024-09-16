using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class PositionMove : MonoBehaviour
    {
        public Vector3 finishPosition;

        public void StartMovePosition(float time)
        {
            StartCoroutine(MovePosition(time));
        }
        
        private IEnumerator MovePosition(float time)
        {
            var startPosition = transform.position;
            var beginTime = time;
            
            while (time > 0)
            {
                transform.position = Vector3.Lerp(startPosition, finishPosition, 1 - (time/beginTime));
                
                time -= Time.fixedDeltaTime;

                yield return new WaitForFixedUpdate();
            }
        }
    }
}