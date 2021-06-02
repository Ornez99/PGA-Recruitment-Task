using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [Inject]
    private MainManager mainManager;

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
        if (mainManager.GameStarted == false)
            return;

        Vector3 moveDirection = controller.MovementVector3;
        movement.Move(moveDirection);
    }

    private void Update()
    {
        if (mainManager.GameStarted == false)
            return;

        float rotationStrength = controller.RotationStrength;
        movement.RotateRight(rotationStrength);
    }

    private void LateUpdate()
    {
        controller.Tick();
    }

}
