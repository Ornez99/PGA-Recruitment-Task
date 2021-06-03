using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool buildable;
    public Vector3 position;
    public Vector3 centerPosition;
    public int xId;
    public int yId;
    public float speed;

    public Node(bool buildable, int xId, int yId)
    {
        this.xId = xId;
        this.yId = yId;
        this.buildable = buildable;
        this.position = new Vector3(xId, 0, yId);
        this.centerPosition = new Vector3(xId + 0.5f, 0, yId + 0.5f);
    }
}
