using UnityEngine;
using Zenject;

public class Chest : MonoBehaviour
{
    [Inject]
    private TwoOptionsWindowFactory twoOptionsWindowFactory;

    private bool isOpened = false;
    private bool windowIsOpened = false;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField]
    private new BoxCollider collider = default;

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
        skinnedMeshRenderer.material.SetColor("_Color", Color.red);
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
    }
}
