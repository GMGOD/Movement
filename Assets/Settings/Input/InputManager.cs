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
public class InputManager : MonoBehaviour
{
    private Controls controls;
    public InputCrouchEventBool crouchInputEvent;
    public InputMenuEventBool menuInputEvent;
    public InputEventVector2 moveInputEvent;
    public InputRunEventBool runInputEvent;

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Menu.Enable();
        controls.Player.Move.performed += OnMove;
        controls.Player.Move.canceled += OnMove;
        controls.Player.Run.performed += OnRun;
        controls.Player.Run.canceled += OnRun;
        controls.Player.Crouch.performed += OnCrouch;
        controls.Player.Crouch.canceled += OnCrouch;
        controls.Menu.Escape.performed += OnMenu;
        //controls.Menu.Escape.canceled += OnMenu;
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
}
