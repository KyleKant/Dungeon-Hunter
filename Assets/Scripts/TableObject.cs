using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableObject : BaseStorage
{
  // [SerializeField] private EquipmentObjectSO equipmentObjectSO;
  // private tableTopPoint;
  private const string TABLE_TOP_POINT = "TableTopPoint";
  public override void Interact(Player player)
  {
    // Debug.Log("Player have something? " + player.HasEquipmentObject());
    // Debug.Log("Table have something? " + HasEquipmentObject());
    if (!HasEquipmentObject())
    {
      // There is nothing on the table object
      if (player.HasEquipmentObject())
      {
        // player is carring something
        if (player.equipmentObjectList.Count != 0)
        {
          EquipmentObject equipmentObjectFirstDrop = player.equipmentObjectList[0];
          player.equipmentObjectList.Remove(equipmentObjectFirstDrop);
          // equipmentObjectFirstDrop.transform.SetParent(this.transform);
          player.GetEquipmentObject(equipmentObjectFirstDrop).SetEquipmentObjectParent(this);
          // player.SetEquipmentObject()
          this.SetEquipmentObject(equipmentObjectFirstDrop);
        }
      }
      else
      {
        // player is not carring something
      }
    }
    else
    {
      // There is something on the table object
      if (!player.HasEquipmentObject())
      {
        // player is not carring something
        this.GetEquipmentObject(equipmentObject).SetEquipmentObjectParent(player);
        Debug.Log("EquipmentObject: " + equipmentObject);
      }
      else
      {
        // player is carring something
        this.GetEquipmentObject(equipmentObject).SetEquipmentObjectParent(player);
      }
    }
  }
}
