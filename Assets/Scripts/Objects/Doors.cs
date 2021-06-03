using UnityEngine;
using System;
using Zenject;
using System.Collections;
using System.Collections.Generic;

public class Doors : MonoBehaviour
{
    private TwoOptionsWindowFactory twoOptionsWindowFactory;
    private OneOptionWindowFactory oneOptionWindowFactory;

    [SerializeField]
    private List<MeshRenderer> meshRenderers;
    [SerializeField]
    private ItemData keyData;
    [SerializeField]
    private Animator animator;

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

    [Inject]
    public void Construct(TwoOptionsWindowFactory twoOptionsWindowFactory, OneOptionWindowFactory oneOptionWindowFactory)
    {
        this.twoOptionsWindowFactory = twoOptionsWindowFactory;
        this.oneOptionWindowFactory = oneOptionWindowFactory;
    }

    public void Highlight()
    {
        foreach(MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material.SetColor("_Color", new Color32(180, 255, 180, 255));
        }
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
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material.SetColor("_Color", Color.white);
        }
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
        animator.SetBool("Opened", DoorsOpened);
        StartCoroutine(ChangeDoorsState());
    }

    private IEnumerator ChangeDoorsState()
    {
        yield return new WaitForSeconds(1);
        if (ChangeDoorStateEvent != null)
            ChangeDoorStateEvent();
    }

    public class Factory : PlaceholderFactory<Doors> { }
}