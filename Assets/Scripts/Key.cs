using UnityEngine;
using Zenject;

public class Key : MonoBehaviour, IInteractable
{

    [Inject]
    private TwoOptionsWindowFactory twoOptionsWindowFactory;

    private bool windowIsOpened = false;
    [SerializeField]
    private MeshRenderer meshRenderer;

    [SerializeField]
    private ItemData keyData;

    private GameObject interactedBy;

    public void Highlight()
    {
        meshRenderer.material.SetColor("_Color", Color.red);
    }

    public void Interact(GameObject interactedBy)
    {
        if (windowIsOpened == false)
        {
            this.interactedBy = interactedBy;

            windowIsOpened = true;
            WindowOption[] options = new WindowOption[2];
            options[0] = new WindowOption(PickKey, "Podnies");
            options[1] = new WindowOption(CloseWindow, "Nie podnos");
            twoOptionsWindowFactory.CreateWindow("Klucz", "Czy chcesz podniesc klucz?", options);
        }
    }

    public void Unhighlight()
    {
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
}
