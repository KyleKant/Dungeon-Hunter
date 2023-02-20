using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInput : MonoBehaviour
{
  public event EventHandler OnClickAction;
  public event EventHandler OnInteractAction;
  private PlayerInputActions playerInputActions;
  private bool focus = true;
  private void Awake()
  {
    playerInputActions = new PlayerInputActions();
    playerInputActions.Player.Enable();
    playerInputActions.Player.Interact.performed += Interact_performed;
    playerInputActions.UI.Enable();
    playerInputActions.UI.Click.performed += Click_performed;
    playerInputActions.Player.Focus.Enable();
    // playerInputActions.UI.Point.performed += Point_performed;
  }

  // private void Point_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  // {
  //   Debug.Log("obj: " + obj);
  // }
  private void Click_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  {
    OnClickAction?.Invoke(this, EventArgs.Empty);
    // Debug.Log("position mouse: " + GetMousePosition());

  }

  private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  {
    if (OnInteractAction != null)
    {
      OnInteractAction(this, EventArgs.Empty);
    }
    // OnInteractAction?.Invoke(this, EventArgs.Empty);
  }
  public Vector2 GetMovementVector()
  {
    Vector2 inputVector = new Vector2();
    inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

    // inputVector = inputVector.normalized;

    return inputVector;
  }

  public Vector2 GetMousePosition()
  {
    Vector2 inputVector = new Vector2();
    inputVector = playerInputActions.UI.Point.ReadValue<Vector2>();
    return inputVector;
  }
  public bool ToggleFocus()
  {
    if (playerInputActions.Player.Focus.triggered)
    {
      focus = !focus;
      Debug.Log("focus: " + focus);
    }
    return focus;
  }
}
