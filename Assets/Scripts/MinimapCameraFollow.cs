using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraFollow : MonoBehaviour
{
  [SerializeField] private MinimapSettings settings;
  [SerializeField] private float cameraHeight;
  private void Awake()
  {
    settings = GetComponentInParent<MinimapSettings>();
    cameraHeight = transform.position.y;
  }
  private void Update()
  {
    Vector3 targetPosition = new Vector3();
    targetPosition = settings.targetFollow.transform.position;
    // Debug.Log("Player's position: " + targetPosition);
    transform.position = new Vector3(
        targetPosition.x,
        targetPosition.y + cameraHeight,
        targetPosition.z
    );
    if (settings.rotateFollowTarget)
    {
      // rotateFollowTarget flag is set true
      Quaternion targetRotation = settings.targetFollow.transform.rotation;
      Debug.Log("targetRotation:" + targetRotation);
      transform.rotation = Quaternion.Euler(
        90,
        targetRotation.eulerAngles.y,
        0
      );
    }
    else
    {
      // rotateFollowTarget flag is set false
      transform.rotation = Quaternion.Euler(90, 0, 0);
    }
  }
}
