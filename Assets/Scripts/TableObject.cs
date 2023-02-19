using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableObject : BaseStorage
{
  private const string TABLE_TOP_POINT = "TableTopPoint";
  public override void Interact(Player player)
  {
    if (!HasItemObject())
    {
      // There is nothing on the table object
      if (player.HasItemObject())
      {
        // player is carrying something
        if (player.itemObjectList.Count != 0)
        {
          ItemController itemObjectFirstDrop = player.itemObjectList[0];
          player.itemObjectList.Remove(itemObjectFirstDrop);
          player.GetItemObject(itemObjectFirstDrop).SetItemObjectParent(this);
          this.SetItemObject(itemObjectFirstDrop);
        }
      }
      else
      {
        // player is not carrying something
      }
    }
    else
    {
      // There is something on the table object
      if (!player.HasItemObject())
      {
        // player is not carrying something
        this.GetItemObject(itemObject).SetItemObjectParent(player);
      }
      else
      {
        // player is carrying something
        this.GetItemObject(itemObject).SetItemObjectParent(player);
      }
    }
  }
}
