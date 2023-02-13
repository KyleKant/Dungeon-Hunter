using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
  public event EventHandler OnInteractAction;
  private PlayerInputActions playerInputActions;
  private void Awake()
  {
    playerInputActions = new PlayerInputActions();
    playerInputActions.Player.Enable();
    playerInputActions.Player.Interract.performed += Interract_performed;
  }
  private void Interract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  {
    if (OnInteractAction != null)
    {
      OnInteractAction(this, EventArgs.Empty);
    }
    // OnInteractAction?.Invoke(this, EventArgs.Empty);
  }
  public Vector2 GetMovementVectorNormalized()
  {
    Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

    inputVector = inputVector.normalized;
    // Debug.Log(inputVector);

    return inputVector;
  }
}
