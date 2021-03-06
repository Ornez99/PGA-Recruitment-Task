using UnityEngine;
using Zenject;

public class InteractableDetector : MonoBehaviour
{
    private IInteractable currentInteractable;
    private IController controller;
    private MainManager mainManager;
    [SerializeField] private float interactDistance;

    [Inject]
    private void Construct(IController controller, MainManager mainManager)
    {
        this.controller = controller;
        this.mainManager = mainManager;
    }

    public void Update()
    {
        if (mainManager.GameStarted == false)
            return;

        GameObject potentialInteractableGO = controller.HoveredGameObject;
        IInteractable potentialInteractable = potentialInteractableGO?.GetComponent<IInteractable>();

        if (potentialInteractableGO == null || Vector3.Distance(transform.position, potentialInteractableGO.transform.position) > interactDistance)
            potentialInteractable = null;

        if (potentialInteractable == null)
        {
            if (currentInteractable != null)
                currentInteractable.Unhighlight();
            currentInteractable = null;
            return;
        }
        else if (currentInteractable != potentialInteractable)
        {
            if (currentInteractable != null)
                currentInteractable.Unhighlight();
            currentInteractable = potentialInteractable;
            currentInteractable.Highlight();
        }

        if (controller.MouseClicked)
            currentInteractable.Interact(gameObject);
    }
}
