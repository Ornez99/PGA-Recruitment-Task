using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    Vector3 MovementVector3 { get; }
    float RotationStrength { get; }
}
