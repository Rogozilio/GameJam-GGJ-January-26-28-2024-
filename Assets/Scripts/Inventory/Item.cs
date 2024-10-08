﻿using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.Inventory
{
    [CreateAssetMenu]
    public class Item : ScriptableObject
    {
        public string itemName;
        public Sprite icon;
        public string description;
    }
}