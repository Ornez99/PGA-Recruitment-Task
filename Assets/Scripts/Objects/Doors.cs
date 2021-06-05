using UnityEngine;
using System;
using Zenject;
using System.Collections;

public class Doors : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ItemData keyData;
    [SerializeField] private Animator animator;
    [SerializeField] private WindowDisplayer windowDisplayer;
    [SerializeField] private BoxCollider boxCollider;
    private GameObject interactedBy;

    public event Action ChangeDoorStateEvent;
    public bool DoorsOpened { get; private set; }

    public void SetInteractedByGameObject(GameObject interactedBy)
    {
        this.interactedBy = interactedBy;
    }

    public void TryToOpenDoors()
    {
        Equipment equipment = interactedBy.GetComponent<Equipment>();

        if (equipment.HaveItem(keyData))
            windowDisplayer.ShowWindow(1);
        else
            windowDisplayer.ShowWindow(0);
    }

    public void OpenDoors()
    {
        if(DoorsOpened == false)
        {
            boxCollider.enabled = false;
            DoorsOpened = true;
            animator.SetBool("Opened", DoorsOpened);
            StartCoroutine(ChangeDoorsState());
            audioSource?.Play();
        }
    }

    private IEnumerator ChangeDoorsState()
    {
        yield return new WaitForSeconds(1);
        if (ChangeDoorStateEvent != null)
            ChangeDoorStateEvent();
    }

    public class Factory : PlaceholderFactory<Doors> { }
}