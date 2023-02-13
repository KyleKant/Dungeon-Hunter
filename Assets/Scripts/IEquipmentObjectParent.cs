using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipmentObjectParent
{
  public Transform GetEquipmentObjectFollowTransform();
  public void SetEquipmentObject(EquipmentObject equipmentObject);
  public EquipmentObject GetEquipmentObject(EquipmentObject equipmentObject);
  public void ClearEquipmentObject();
  public bool HasEquipmentObject();
}
