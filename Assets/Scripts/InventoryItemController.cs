using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
  private ItemObjectSO itemObjectSO;
  public void RemoveItem()
  {
    InventoryManager.Instance.Remove(itemObjectSO);
    Destroy(gameObject);
  }
  public void AddItem(ItemObjectSO newItem)
  {
    itemObjectSO = newItem;
  }
}
