using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
    {
        public Image icon;

        public void UpdateItemDisplay(Sprite itemIcon, int index)
        {
            if (itemIcon)
                icon.enabled = true;
            else 
                icon.enabled = false;
            icon.sprite = itemIcon;
            icon.color = Color.white;
        }
    }