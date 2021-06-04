using System;
using UnityEngine;

[Serializable]
public class Item
{
    [SerializeField] private ItemData data;

    public ItemData Data { get => data; }

    public Item(ItemData itemData)
    {
        data = itemData;
    }
}
