using UnityEngine;

public interface IController
{
    void Tick();
    GameObject HoveredGameObject { get; }
    bool MouseClicked { get; }
    Vector3 MovementVector3 { get; }
    float RotationStrength { get; }
}
