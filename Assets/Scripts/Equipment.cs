using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private List<Item> items = new List<Item>();

    public void AddItem(ItemData itemData)
    {
        Item newItem = new Item(itemData);
        items.Add(newItem);
    }

    public bool HaveItem(ItemData itemData)
    {
        foreach(Item item in items)
        {
            if (itemData.ItemName == item.Data.ItemName)
                return true;
        }

        return false;
    }
}
