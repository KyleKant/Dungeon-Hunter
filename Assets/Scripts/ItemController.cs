using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
  [SerializeField] private ItemObjectSO itemObjectSO;
  public IItemParent itemParent;
  public ItemObjectSO GetItemObjectSO()
  {
    return itemObjectSO;
  }
  public void SetItemObjectParent(IItemParent itemParent)
  {
    if (this.itemParent != null)
    {
      this.itemParent.ClearItemObject();
    }
    this.itemParent = itemParent;
    this.itemParent.SetItemObject(this);
    transform.parent = this.itemParent.GetItemObjectFollowTransform();
    transform.localPosition = Vector3.zero;
  }
  public IItemParent GetItemParent()
  {
    return itemParent;
  }
  public void DestroySelf()
  {
    itemParent.ClearItemObject();
    Destroy(gameObject);
  }
  public static ItemController SpawnItemObject(ItemObjectSO itemObjectSO, IItemParent itemParent)
  {
    Transform itemObjectTransform = Instantiate(itemObjectSO.prefab);
    ItemController itemObject = itemObjectTransform.GetComponent<ItemController>();
    itemObject.SetItemObjectParent(itemParent);
    return itemObject;
  }
}
