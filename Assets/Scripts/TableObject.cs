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
        if (player.GetChildObjectCount(player.transform.GetChild(1)) != 0)
        {
          Debug.Log("player.GetEquipmentObject(); " + player.GetEquipmentObject());
          List<Transform> equipmentObjectList = new List<Transform>();
          // Debug.Log("Child of player: " + player.transform.GetChild(1));
          equipmentObjectList = player.GetChildObjectList(player.transform.GetChild(1), player.GetChildObjectCount(player.transform.GetChild(1)));
          Transform equipmentObjectDrop = equipmentObjectList[0];
          // Debug.Log("equipmentObjectDrop: " + equipmentObjectDrop);
          equipmentObjectList.Remove(equipmentObjectDrop);
          equipmentObjectDrop.SetParent(this.transform.Find(TABLE_TOP_POINT));
          equipmentObjectDrop.transform.position = baseStorageTopPoint.position;
          // Debug.Log("Parent of equipment: ");
          equipmentObjectList.Clear();
        }
        // player.GetEquipmentObject().SetEquipmentObjectParent(this);
        // Debug.Log("player.GetEquipmentObject(); " + player.GetEquipmentObject());
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
        Debug.Log("Here");
        // player is not carring something
        this.GetEquipmentObject().SetEquipmentObjectParent(player);
      }
      else
      {
        // player is carring something
      }
    }
    Debug.Log("Player have something? " + player.HasEquipmentObject());
    Debug.Log("Table have something? " + HasEquipmentObject());
  }
}
