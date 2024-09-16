using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Dead : MonoBehaviour
    {
        public GameObject player;
        public GameObject playerBoom;

        private MovePlayer _movePlayer;

        private void Awake()
        {
            _movePlayer = GetComponent<MovePlayer>();
        }

        public void SkeletBoom()
        {
            player.SetActive(false);
            playerBoom.SetActive(true);
            _movePlayer.enabled = false;
            StartCoroutine(TimeDead());
        }

        private IEnumerator TimeDead()
        {
             yield return new WaitForSeconds(1.9f);
             
             player.SetActive(true);
             playerBoom.SetActive(false);
             _movePlayer.enabled = true;
        }
    }
}