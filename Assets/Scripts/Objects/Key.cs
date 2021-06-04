using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Key : MonoBehaviour
{
    private TwoOptionsWindowFactory twoOptionsWindowFactory;
    private bool windowIsOpened = false;
    [SerializeField] private ItemData keyData;
    private GameObject interactedBy;

    public UnityEvent<Vector3> PickUpEvent;

    private void Start()
    {
        
    }

    [Inject]
    public void Construct(TwoOptionsWindowFactory twoOptionsWindowFactory)
    {
        this.twoOptionsWindowFactory = twoOptionsWindowFactory;
    }

    public void Interact(GameObject interactedBy)
    {
        if (windowIsOpened == false)
        {
            this.interactedBy = interactedBy;
            windowIsOpened = true;
            DisplayOpenChestWindow();
        }
    }

    private void DisplayOpenChestWindow()
    {
        WindowOption[] options = new WindowOption[2];
        options[0] = new WindowOption(PickKey, "Podnies");
        options[1] = new WindowOption(CloseWindow, "Nie podnos");
        twoOptionsWindowFactory.CreateWindow("Klucz", "Czy chcesz podniesc klucz?", options);
    }

    public void CloseWindow()
    {
        windowIsOpened = false;
    }

    private void PickKey()
    {
        Equipment equipment = interactedBy.GetComponent<Equipment>();
        equipment.AddItem(keyData);
        if (PickUpEvent != null)
            PickUpEvent.Invoke(transform.position);
        Destroy(gameObject);
    }

    public class Factory : PlaceholderFactory<Key> { }
}
