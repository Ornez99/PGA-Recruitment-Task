using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeshHighlighter : MonoBehaviour, IHighlighter
{
    [SerializeField] private List<MeshRenderer> meshRenderers;
    [SerializeField] private List<SkinnedMeshRenderer> skinnedMeshRenderer;
    [SerializeField] private Color32 defaultColor;
    [SerializeField] private Color32 highlightedColor;

    public UnityEvent HighlightEvent;
    public UnityEvent UnhighlightEvent;

    public void Highlight()
    {
        for(int i = 0; i < meshRenderers.Count; i++)
        {
            meshRenderers[i].material.SetColor("_Color", highlightedColor);
        }
        for (int i = 0; i < skinnedMeshRenderer.Count; i++)
        {
            skinnedMeshRenderer[i].material.SetColor("_Color", highlightedColor);
        }

        if (HighlightEvent != null)
            HighlightEvent.Invoke();
    }

    public void Unhighlight()
    {
        for (int i = 0; i < meshRenderers.Count; i++)
        {
            meshRenderers[i].material.SetColor("_Color", defaultColor);
        }
        for (int i = 0; i < skinnedMeshRenderer.Count; i++)
        {
            skinnedMeshRenderer[i].material.SetColor("_Color", defaultColor);
        }

        if (UnhighlightEvent != null)
            UnhighlightEvent.Invoke();
    }
}
