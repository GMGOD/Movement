using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable]
public class InputEventVector2 : UnityEvent<float, float> { }
[Serializable]
public class InputCrouchEventBool : UnityEvent<bool> { }
[Serializable]
public class InputRunEventBool : UnityEvent<bool> { }
[Serializable]
public class InputMenuEventBool : UnityEvent<bool> { }
[Serializable]
public class InputEEventBool : UnityEvent<bool> { }
public class InputManager : MonoBehaviour
{
    private Controls controls;
    public InputCrouchEventBool crouchInputEvent;
    public InputMenuEventBool menuInputEvent;
    public InputEventVector2 moveInputEvent;
    public InputRunEventBool runInputEvent;
    public InputEEventBool EInputEvent;

    private void Awake()
    {
        controls = new Controls();
    }
    public void DisabledInputsPlayer()
    {
        controls.Player.Disable();
        controls.IngresarNombre.Disable();
    }
    public void EnableInputsPlayer()
    {
        controls.Player.Enable();
        controls.IngresarNombre.Enable();
    }
    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Menu.Enable();
        controls.IngresarNombre.Enable();

        controls.Player.Move.performed += OnMove;
        controls.Player.Move.canceled += OnMove;
        controls.Player.Run.performed += OnRun;
        controls.Player.Run.canceled += OnRun;
        controls.Player.Crouch.performed += OnCrouch;
        controls.Player.Crouch.canceled += OnCrouch;
        controls.Menu.Escape.performed += OnMenu;
        //controls.Menu.Escape.canceled += OnMenu;
        controls.IngresarNombre.E.performed += OnE;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        moveInputEvent.Invoke(moveInput.x, moveInput.y);
    }

    private void OnRun(InputAction.CallbackContext context)
    {
        bool runInput = context.ReadValueAsButton();
        runInputEvent.Invoke(runInput);
    }

    private void OnCrouch(InputAction.CallbackContext context)
    {
        bool crouchInput = context.ReadValueAsButton();
        crouchInputEvent.Invoke(crouchInput);
    }

    private void OnMenu(InputAction.CallbackContext context)
    {
        bool menuInput = context.ReadValueAsButton();
        Debug.Log($"Menu ! {menuInput}");
        menuInputEvent.Invoke(menuInput);
    }

    private void OnE(InputAction.CallbackContext context)
    {
        bool eInput = context.ReadValueAsButton();
        EInputEvent.Invoke(eInput);
    }
}
