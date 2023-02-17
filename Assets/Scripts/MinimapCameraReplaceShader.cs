using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraReplaceShader : MonoBehaviour
{
  [SerializeField] private Camera targetCamera;
  private const string UNLIT_TEXTURE = "Unlit/Color";
  private void Start()
  {
    targetCamera.SetReplacementShader(Shader.Find(UNLIT_TEXTURE), "RenderType");
  }
}
