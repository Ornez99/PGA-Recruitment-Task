using Zenject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private IController controller;
    private IMoveable movement;

    [Inject]
    private void Construct (IController controller, IMoveable movement)
    {
        this.controller = controller;
        this.movement = movement;
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = controller.MovementVector3;
        movement.Move(moveDirection);
        float rotationStrength = controller.RotationStrength;
        movement.RotateRight(rotationStrength);
    }

}
