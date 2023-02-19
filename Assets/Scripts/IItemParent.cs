using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemParent
{
  public void ClearItemObject();
  public void SetItemObject(ItemController itemObject);
  public Transform GetItemObjectFollowTransform();
  public ItemController GetItemObject(ItemController itemObject);
  public bool HasItemObject();
}
