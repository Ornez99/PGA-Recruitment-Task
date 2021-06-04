using System.Collections;
using UnityEngine;
using Zenject;

public class Chest : MonoBehaviour
{
    private TwoOptionsWindowFactory twoOptionsWindowFactory;
    private bool isOpened = false;
    private bool windowIsOpened = false;
    [SerializeField] private Animator anim;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private new BoxCollider collider = default;
    [SerializeField] private Equipment equipment;
    [SerializeField] private AudioSource audioSource;
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
        skinnedMeshRenderer.material.SetColor("_Color", new Color32(180, 255, 180, 255));
    }

    public void Interact(GameObject interactedBy)
    {
        if (isOpened == false && windowIsOpened == false)
        {
            windowIsOpened = true;
            DisplayOpenChestWindow();
        }
    }

    public void Unhighlight()
    {
        skinnedMeshRenderer.material.SetColor("_Color", Color.white);
    }

    public void CloseWindow()
    {
        windowIsOpened = false;
    }

    private void DisplayOpenChestWindow()
    {
        WindowOption[] options = new WindowOption[2];
        options[0] = new WindowOption(OpenChest, "Otworz");
        options[1] = new WindowOption(CloseWindow, "Nie otwieraj");
        twoOptionsWindowFactory.CreateWindow("Skrzynia", "Czy chcesz otworzyc skrzynie?", options);
    }

    public void OpenChest()
    {
        isOpened = true;
        anim.SetBool("IsOpened", isOpened);
        windowIsOpened = false;
        collider.enabled = false;
        StartCoroutine(equipment.DropItems());
        StartCoroutine(PlayOpenSound());
    }

    private IEnumerator PlayOpenSound()
    {
        audioSource.Play();
        yield return new WaitForSeconds(1);
        audioSource.Stop();
    }

    public class Factory : PlaceholderFactory<Chest> { }
}
