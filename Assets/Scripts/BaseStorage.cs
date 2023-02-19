using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStorage : MonoBehaviour, IItemParent
{
  [SerializeField] public Transform baseStorageTopPoint;
  // public EquipmentObject equipmentObject;
  public ItemController itemObject;
  public virtual void Interact(Player player)
  {
    Debug.LogError("BaseStorage.Interact();");
  }

  public void SetItemObject(ItemController itemObject)
  {
    this.itemObject = itemObject;
  }
  public void ClearItemObject()
  {
    itemObject = null;
  }
  public ItemController GetItemObject(ItemController itemObject)
  {
    return itemObject;
  }

  public Transform GetItemObjectFollowTransform()
  {
    return baseStorageTopPoint;
  }

  public bool HasItemObject()
  {
    return itemObject != null;
  }
}
