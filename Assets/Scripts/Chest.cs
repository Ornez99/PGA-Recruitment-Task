using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public void Highlight()
    {
        //GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    public void Interact()
    {
        Debug.Log($"Interacted with {name}");
    }

    public void Unhighlight()
    {
        //GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }
}
