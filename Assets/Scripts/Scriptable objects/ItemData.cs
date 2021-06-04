using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 1)]
[Serializable]
public class ItemData : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private string description;
    [SerializeField] private GameObject prefab;

    public string ItemName { get => itemName; set => itemName = value; }
    public string Description { get => description; set => description = value; }
    public GameObject Prefab { get => prefab; set => prefab = value; }
}
