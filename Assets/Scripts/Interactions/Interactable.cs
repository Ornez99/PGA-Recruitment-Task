using System;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    public UnityEvent HighlightEvent;
    public UnityEvent UnhighlightEvent;
    public UnityEvent<GameObject> InteractEvent;

    public void Highlight()
    {
        if (HighlightEvent != null)
            HighlightEvent.Invoke();
    }

    public void Interact(GameObject interactedBy)
    {
        if (InteractEvent != null)
            InteractEvent.Invoke(interactedBy);
    }

    public void Unhighlight()
    {
        if (UnhighlightEvent != null)
            UnhighlightEvent.Invoke();
    }
}
