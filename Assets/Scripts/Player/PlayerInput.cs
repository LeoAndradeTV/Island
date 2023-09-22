using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance { get; private set; }
    public bool IsInteracting { get; private set; }

    private PlayerInputActions inputActions;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
        inputActions.Player.Interact.performed += Interact_performed;
        inputActions.Player.Interact.canceled += Interact_canceled;
    }

    private void Interact_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        IsInteracting = false;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        IsInteracting = true;
    }

    public Vector3 GetMovementInput()
    {
        Vector2 input = inputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(input.x, 0, input.y);
        return moveDir.normalized;
    }

}
