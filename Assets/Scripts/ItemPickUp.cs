using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
  public ItemObjectSO item;
  private void PickUp()
  {
    InventoryManager.Instance.Add(item);
    Destroy(gameObject);

  }
  private void OnMouseDown()
  {
    PickUp();
  }
}
