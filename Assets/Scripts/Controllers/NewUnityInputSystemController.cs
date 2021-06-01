using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewUnityInputSystemController : IController
{
    private Vector3 movementVector3 = default;
    private float rotationStrength = 0;
    private InputActionAsset controls;
    private InputActionMap inputActionMap;
    private InputAction rotateAction;

    public Vector3 MovementVector3 { get => movementVector3; }
    public float RotationStrength { get => rotationStrength; }

    public NewUnityInputSystemController()
    {
        inputActionMap = controls.FindActionMap("Gameplay");
        rotateAction = inputActionMap.FindAction("Rotate");
        rotateAction.performed += OnRotate;


    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        rotationStrength = context.ReadValue<float>();
    }
}
