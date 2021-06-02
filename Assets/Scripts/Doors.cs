using UnityEngine;
using Zenject;

public class Doors : MonoBehaviour, IInteractable
{
    [Inject]
    private TwoOptionsWindowFactory twoOptionsWindowFactory;

    [Inject]
    private OneOptionWindowFactory oneOptionWindowFactory;

    private bool windowIsOpened = false;
    [SerializeField]
    private MeshRenderer meshRenderer;

    private GameObject interactedBy;

    [SerializeField]
    private ItemData keyData;

    public bool DoorsOpened { get; private set; }

    public void Highlight()
    {
        meshRenderer.material.SetColor("_Color", Color.red);
    }

    public void Interact(GameObject interactedBy)
    {
        if (windowIsOpened == false)
        {
            this.interactedBy = interactedBy;
            Equipment equipment = interactedBy.GetComponent<Equipment>();
            if( equipment.HaveItem(keyData))
                DisplayOpenDoorsWindow();
            else
                DisplayClosedDoorsWindow();
        }
    }

    public void Unhighlight()
    {
        meshRenderer.material.SetColor("_Color", Color.white);
    }

    private void DisplayOpenDoorsWindow()
    {
        windowIsOpened = true;
        WindowOption[] options = new WindowOption[2];
        options[0] = new WindowOption(OpenDoors, "Otworz");
        options[1] = new WindowOption(CloseWindow, "Nie otwieraj");
        twoOptionsWindowFactory.CreateWindow("Drzwi", "Czy chcesz otworzyc drzwi?", options);
    }

    private void DisplayClosedDoorsWindow()
    {
        windowIsOpened = true;
        WindowOption[] options = new WindowOption[1];
        options[0] = new WindowOption(CloseWindow, "Odejdz");
        oneOptionWindowFactory.CreateWindow("Drzwi", "Sa zamkniete, potrzebujesz klucza.", options);
    }

    public void CloseWindow()
    {
        windowIsOpened = false;
    }

    private void OpenDoors()
    {
        DoorsOpened = true;
    }
}