using System;
using System.Collections.Generic;
using DefaultNamespace.Inventory;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;

public class Inventory : MonoBehaviour
{
    [Serializable]
    public struct ActionItem
    {
        public Item item;
        public UnityEvent action;
    }
    
    public InventoryDisplay inventoryDisplay;
    public List<Item> items = new List<Item>();
    public List<ActionItem> actionItems = new List<ActionItem>();
    [Space] 
    public List<AudioClip> hahaSounds;
    public AudioSource audioSource;
    [Space] public InspectionObject inspectionObject;

    private int _indexActiveItem = 0;

    public void AddItem(Item itemToAdd)
    {
        items.Add(itemToAdd);
        inventoryDisplay.UpdateInventory();
    }

    public void RemoveItem(Item itemToRemove)
    {
        items.Remove(itemToRemove);
        inventoryDisplay.UpdateInventory();
    }

    public void CheckRightItem(Item item)
    {
        if (_indexActiveItem < items.Count && items[_indexActiveItem] == item)
        {
            LaunchActionItem(item);
        }
        else
        {
            PlayHAHAHA();
        }
    }

    private void LaunchActionItem(Item item)
    {
        foreach (var actionItem in actionItems)
        {
            if (actionItem.item == item)
            {
                actionItem.action?.Invoke();
                return;
            }
        }
    }

    public void PlayHAHAHA()
    {
        audioSource.clip = hahaSounds[new Random().Next(hahaSounds.Count)];
        audioSource.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _indexActiveItem = 0;
            inventoryDisplay.ActiveItemInInventory(_indexActiveItem);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _indexActiveItem = 1;
            inventoryDisplay.ActiveItemInInventory(_indexActiveItem);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _indexActiveItem = 2;
            inventoryDisplay.ActiveItemInInventory(_indexActiveItem);
        }

        InspectObject();
    }

    private void InspectObject()
    {
        if (Input.GetKeyDown(KeyCode.F) && _indexActiveItem < items.Count)
        {
            inspectionObject.StartInspect(items[_indexActiveItem]);
        }
    }
}
