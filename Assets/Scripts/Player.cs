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
        movement.Move(controller.MovementVector3);
        movement.RotateRight(controller.RotationStrength);
    }

}
