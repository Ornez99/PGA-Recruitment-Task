using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class NewUnityInputSystemController : IController
{
    private Vector3 movementVector3 = default;
    private float rotationStrength = 0;
    public InputActionAsset controls;
    private InputActionMap inputActionMap;
    private InputAction rotateAction;
    private InputAction moveAction;
    private Keyboard keyboard;

    public Vector3 MovementVector3 { get => movementVector3; }
    public float RotationStrength { get => rotationStrength; }

    public NewUnityInputSystemController()
    {

    }

    [Inject]
    public NewUnityInputSystemController(InputActionAsset controls)
    {
        this.controls = controls;
        keyboard = Keyboard.current;
        inputActionMap = controls.FindActionMap("Player");
        AddActions();
    }

    private void AddActions()
    {
        rotateAction = inputActionMap.FindAction("Rotate");
        rotateAction.performed += OnRotate;
        rotateAction.canceled += OnRotateEnd;

        moveAction = inputActionMap.FindAction("Move");
        moveAction.performed += OnMove;
        moveAction.canceled += OnMoveEnd;
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        rotationStrength = context.ReadValue<float>();
    }

    public void OnRotateEnd(InputAction.CallbackContext context)
    {
        rotationStrength = 0;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        movementVector3 = new Vector3(value.x, 0, value.y);
    }

    public void OnMoveEnd(InputAction.CallbackContext context)
    {
        movementVector3 = Vector3.zero;
    }
}
