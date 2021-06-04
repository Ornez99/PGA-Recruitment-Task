using System;
using UnityEngine;
using Zenject;

public class NodeChangeDetector : MonoBehaviour
{
    private Map map;
    private Node currentNode;

    public event Action<Node> ChangeClosestNodeEvent;

    [Inject]
    private void Construct(Map map)
    {
        this.map = map;
    }

    private void FixedUpdate()
    {
        Node closestNode = map.GetNodeFromPos(transform.position);
        if(closestNode != null && currentNode != closestNode)
        {
            currentNode = closestNode;
            if (ChangeClosestNodeEvent != null)
                ChangeClosestNodeEvent(currentNode);
        }
    }
}
