using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedObjectVisual : MonoBehaviour
{
  [SerializeField] private BaseStorage baseStorage;
  [SerializeField] private GameObject visualGameObject;
  private void Start()
  {
    Player.Instance.OnSelectedObjectChanged += Player_OnSelectedObjectChanged;
  }
  private void Player_OnSelectedObjectChanged(object sender, Player.OnSelectedObjectChangedEventArgs e)
  {
    if (e.selectedObject == baseStorage)
    {
      Show();
    }
    else
    {
      Hide();
    }
  }
  private void Show()
  {
    if (visualGameObject != null)
    {
      visualGameObject.SetActive(true);
    }
  }
  private void Hide()
  {
    if (visualGameObject != null)
    {
      visualGameObject.SetActive(false);

    }
  }
}
