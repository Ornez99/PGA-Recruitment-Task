using System;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    public event Action HighlightEvent;
    public event Action UnhighlightEvent;
    public event Action<GameObject> InteractEvent;

    public void Highlight()
    {
        if (HighlightEvent != null)
            HighlightEvent();
    }

    public void Interact(GameObject interactedBy)
    {
        if (InteractEvent != null)
            InteractEvent(interactedBy);
    }

    public void Unhighlight()
    {
        if (UnhighlightEvent != null)
            UnhighlightEvent();
    }
}
