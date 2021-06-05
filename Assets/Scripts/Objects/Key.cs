using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Key : MonoBehaviour
{
    [SerializeField] private ItemData keyData;
    private GameObject interactedBy;

    public UnityEvent<Vector3> PickUpEvent;

    public void SetInteractedByGameObject(GameObject interactedBy)
    {
        this.interactedBy = interactedBy;
    }

    public void PickKey()
    {
        Equipment equipment = interactedBy.GetComponent<Equipment>();
        equipment.AddItem(keyData);
        if (PickUpEvent != null)
            PickUpEvent.Invoke(transform.position);
        Destroy(gameObject);
    }

    public class Factory : PlaceholderFactory<Key> { }
}
