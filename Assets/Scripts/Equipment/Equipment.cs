using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Equipment : MonoBehaviour
{
    [SerializeField]
    private List<Item> items = new List<Item>();

    [SerializeField] private AudioSource audioSource;

    public List<Item> Items { get => items; }

    public void AddItem(ItemData itemData)
    {
        Item newItem = new Item(itemData);
        items.Add(newItem);
        audioSource?.Play();
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

    [Inject]
    Key.Factory keyFactory;

    public IEnumerator DropItems()
    {
        yield return new WaitForSeconds(1);
        foreach (Item item in Items)
        {
            if (item.Data.Prefab != null)
            {
                if (item.Data.Prefab.GetComponent<Key>() != null)
                {
                    Key ins = keyFactory.Create();
                    ins.transform.position = transform.position + Vector3.up * 0.5f;
                    ins.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
                }
                else
                {
                    Instantiate(item.Data.Prefab, transform.position + Vector3.up * 0.5f, Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0));
                }
            }
        }
        items.Clear();
    }
}
