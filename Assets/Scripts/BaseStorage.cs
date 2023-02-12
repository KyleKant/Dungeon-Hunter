using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStorage : MonoBehaviour, IEquipmentObjectParent
{
  [SerializeField] public Transform baseStorageTopPoint;
  private EquipmentObject equipmentObject;
  public virtual void Interact(Player player)
  {
    Debug.LogError("BaseStorage.Interact();");
  }
  // public int GetEquipmentObjectCountWhichCarring(){
  //     int equipmentObjectCountWhichCarring = transform.childCount;
  //     return equipmentObjectCountWhichCarring;
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

  public EquipmentObject GetEquipmentObject()
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
