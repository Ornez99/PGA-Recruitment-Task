using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InteractableDetector : MonoBehaviour
{
    private IInteractable currentInteractable;
    [Inject]
    private IController controller;

    [SerializeField]
    private float interactDistance;

    public void Update()
    {
        GameObject potentialInteractableGO = controller.HoveredGameObject;
        IInteractable potentialInteractable = potentialInteractableGO?.GetComponent<IInteractable>();

        if (potentialInteractableGO == null || Vector3.Distance(transform.position, potentialInteractableGO.transform.position) > interactDistance)
            potentialInteractable = null;

        if (potentialInteractable == null)
        {
            currentInteractable?.Unhighlight();
            currentInteractable = null;
            return;
        }
        else if (currentInteractable != potentialInteractable)
        {
            currentInteractable?.Unhighlight();
            currentInteractable = potentialInteractable;
            currentInteractable.Highlight();
        }

        if (controller.MouseClicked)
            currentInteractable.Interact();
    }


}
