using UnityEngine;
using System;
using Zenject;
using System.Collections;

public class Doors : MonoBehaviour
{
    [Inject]
    private TwoOptionsWindowFactory twoOptionsWindowFactory;
    [Inject]
    private OneOptionWindowFactory oneOptionWindowFactory;
    [SerializeField]
    private MeshRenderer meshRenderer;
    [SerializeField]
    private ItemData keyData;
    private bool windowIsOpened = false;

    public event Action ChangeDoorStateEvent;
    public bool DoorsOpened { get; private set; }

    private Interactable interactable;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
        interactable.HighlightEvent += Highlight;
        interactable.UnhighlightEvent += Unhighlight;
        interactable.InteractEvent += Interact;
    }

    public void Highlight()
    {
        meshRenderer.material.SetColor("_Color", Color.red);
    }

    public void Interact(GameObject interactedBy)
    {
        if (windowIsOpened == false)
        {
            Equipment equipment = interactedBy.GetComponent<Equipment>();
            if (equipment.HaveItem(keyData))
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
        StartCoroutine(ChangeDoorsState());
    }

    private IEnumerator ChangeDoorsState()
    {
        yield return new WaitForSeconds(1);
        if (ChangeDoorStateEvent != null)
            ChangeDoorStateEvent();
    }
}