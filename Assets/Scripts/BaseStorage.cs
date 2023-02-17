using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStorage : MonoBehaviour, IEquipmentObjectParent
{
  [SerializeField] public Transform baseStorageTopPoint;
  public EquipmentObject equipmentObject;
  public virtual void Interact(Player player)
  {
    Debug.LogError("BaseStorage.Interact();");
  }
  // public int GetEquipmentObjectCountWhichCarrying(){
  //     int equipmentObjectCountWhichCarrying = transform.childCount;
  //     return equipmentObjectCountWhichCarrying;
  //   }
  public void SetEquipmentObject(EquipmentObject equipmentObject)
  {
    // Debug.Log("equipmentObject: " + equipmentObject);
    this.equipmentObject = equipmentObject;
  }
  public void ClearEquipmentObject()
  {
    equipmentObject = null;
  }

  public EquipmentObject GetEquipmentObject(EquipmentObject equipmentObject)
  {
    return equipmentObject;
  }

  public Transform GetEquipmentObjectFollowTransform()
  {
    return baseStorageTopPoint;
  }

  public bool HasEquipmentObject()
  {
    return equipmentObject != null;
  }

}
