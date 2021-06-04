using UnityEngine;

public class SpeedModifier : MonoBehaviour
{
    private float baseSpeed = 1f;
    private float nodeSpeed = 1f;

    private void Awake()
    {
        if (GetComponent<NodeChangeDetector>() != null)
            GetComponent<NodeChangeDetector>().ChangeClosestNodeEvent += GetNodeSpeed;
    }

    public float GetSpeed()
    {
        float value = baseSpeed;
        value += nodeSpeed;
        return value;
    }

    public void GetNodeSpeed(Node node)
    {
        nodeSpeed = node.speed;
    }
}
