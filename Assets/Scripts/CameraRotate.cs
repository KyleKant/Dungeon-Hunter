using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
  private const int LEFT_MOUSE = 0;
  private const int RIGHT_MOUSE = 1;
  private const int MIDLE_MOUSE = 2;
  private const string MOUSE_X = "Mouse X";
  private const string MOUSE_Y = "Mouse Y";
  public Vector2 rot;
  public float sensitivity = 1.5f;
  private void Update()
  {
    if (Input.GetMouseButton(LEFT_MOUSE))
    {
      rot.x += Input.GetAxis(MOUSE_X) * sensitivity;
      rot.y += Input.GetAxis(MOUSE_Y) * sensitivity;
      transform.localRotation = Quaternion.Euler(-rot.y, rot.x, 0f);
    }
  }
}
