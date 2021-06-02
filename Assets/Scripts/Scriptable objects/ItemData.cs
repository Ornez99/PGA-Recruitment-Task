using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private string description;

    public string ItemName { get => itemName; set => itemName = value; }
    public string Description { get => description; set => description = value; }
}
