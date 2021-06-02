using UnityEngine;

public interface IInteractable
{
    void Interact(GameObject interactedBy);
    void Highlight();
    void Unhighlight();
}
