using System.Collections;
using UnityEngine;
using Zenject;

public class Chest : MonoBehaviour
{
    private bool isOpened = false;
    [SerializeField] private Animator anim;
    [SerializeField] private new BoxCollider collider = default;
    [SerializeField] private Equipment equipment;
    [SerializeField] private AudioSource audioSource;

    public void OpenChest()
    {
        if(isOpened == false)
        {
            isOpened = true;
            anim.SetBool("IsOpened", isOpened);
            collider.enabled = false;
            StartCoroutine(equipment.DropItems());
            StartCoroutine(PlayOpenSound());
        }
    }

    private IEnumerator PlayOpenSound()
    {
        audioSource.Play();
        yield return new WaitForSeconds(1);
        audioSource.Stop();
    }

    public class Factory : PlaceholderFactory<Chest> { }
}
