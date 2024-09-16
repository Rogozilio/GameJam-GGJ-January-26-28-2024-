using System;
using UnityEngine;
using UnityEngine.UI;


public class InventoryDisplay : MonoBehaviour
    {
        public Inventory inventory;
        public ItemDisplay[] slots;

        private void Start()
        {
            UpdateInventory();
        }

        public void UpdateInventory()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < inventory.items.Count)
                {
                    slots[i].gameObject.SetActive(true);
                    slots[i].UpdateItemDisplay(inventory.items[i].icon, i);
                }
                else 
                {
                    slots[i].gameObject.SetActive(false);
                }
            }
        }

        public void ActiveItemInInventory(int index)
        {
            for (var i = 0; i < slots.Length; i++)
            {
                if(i == index)
                    slots[i].transform.parent.GetChild(1).GetComponent<Image>().color = Color.yellow;
                else
                    slots[i].transform.parent.GetChild(1).GetComponent<Image>().color = Color.white;
            }
        }
    }