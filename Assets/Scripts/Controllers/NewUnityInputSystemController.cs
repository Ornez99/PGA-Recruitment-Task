using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class NewUnityInputSystemController : IController
{
    private InputActionAsset controls;
    private InputActionMap inputActionMap;
    private InputAction rotateAction;
    private InputAction moveAction;
    private InputAction fireAction;

    public Vector3 MovementVector3 { get; private set; }
    public float RotationStrength { get; private set; }
    public GameObject HoveredGameObject { get; private set; }
    public bool MouseClicked { get; private set; }

    public NewUnityInputSystemController()
    {
        HoveredGameObject = null;
    }

    [Inject]
    private void Construct (InputActionAsset controls)
    {
        this.controls = controls;
        inputActionMap = controls.FindActionMap("Player");
        AddActions();
    }

    public void Tick()
    {
        if (MouseClicked)
            MouseClicked = false;

        UpdateHoveredGameObject();
    }

    private void UpdateHoveredGameObject()
    {
        HoveredGameObject = null;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit, 100))
            HoveredGameObject = hit.transform.gameObject;
    }

    private void AddActions()
    {
        rotateAction = inputActionMap.FindAction("Rotate");
        rotateAction.performed += OnRotate;
        rotateAction.canceled += OnRotateEnd;

        moveAction = inputActionMap.FindAction("Move");
        moveAction.performed += OnMove;
        moveAction.canceled += OnMoveEnd;

        fireAction = inputActionMap.FindAction("Fire");
        fireAction.started += OnClick;
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        RotationStrength = context.ReadValue<float>();
    }

    public void OnRotateEnd(InputAction.CallbackContext context)
    {
        RotationStrength = 0;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        MovementVector3 = new Vector3(value.x, 0, value.y);
    }

    public void OnMoveEnd(InputAction.CallbackContext context)
    {
        MovementVector3 = Vector3.zero;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        MouseClicked = true;
    }
}
