using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public void Shake()
    {
        Camera.main.GetComponent<CameraShake>().ShakeCamera();
    }

    public void Shake(Vector3 vector3)
    {
        Camera.main.transform.parent.GetComponent<CameraShake>().ShakeCamera();
    }
}
