using UnityEngine;
using Zenject;

public class Key : MonoBehaviour
{
    private TwoOptionsWindowFactory twoOptionsWindowFactory;
    private bool windowIsOpened = false;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private ItemData keyData;
    private GameObject interactedBy;
    private Interactable interactable;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
        interactable.HighlightEvent += Highlight;
        interactable.UnhighlightEvent += Unhighlight;
        interactable.InteractEvent += Interact;
    }

    [Inject]
    public void Construct(TwoOptionsWindowFactory twoOptionsWindowFactory)
    {
        this.twoOptionsWindowFactory = twoOptionsWindowFactory;
    }

    public void Highlight()
    {
        meshRenderer?.material.SetColor("_Color", new Color32(180, 255, 180, 255));
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

    public void Unhighlight()
    {
        if (meshRenderer != null)
            meshRenderer.material.SetColor("_Color", Color.white);
    }

    public void CloseWindow()
    {
        windowIsOpened = false;
    }

    private void PickKey()
    {
        Equipment equipment = interactedBy.GetComponent<Equipment>();
        equipment.AddItem(keyData);
        Destroy(gameObject);
    }

    public class Factory : PlaceholderFactory<Key> { }
}
