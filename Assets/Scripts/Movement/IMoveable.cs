using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    void Move(Vector3 direction);
    void RotateRight(float strength);
}
