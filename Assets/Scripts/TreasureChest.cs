using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : BaseStorage
{
  private const string EQUIPMENT_OBJECT_DROP_POINT = "EquipmentObjectDropPoint";
  public event EventHandler OnPlayerInteractTreasureChest;
  [SerializeField] private EquipmentObjectSO[] equipmentObjectSOArray;
  private EquipmentObjectSO equipmentObjectSO;
  private int randomEquipmentObjectSO;


  public override void Interact(Player player)
  {
    randomEquipmentObjectSO = UnityEngine.Random.Range(0, equipmentObjectSOArray.Length);
    equipmentObjectSO = equipmentObjectSOArray[randomEquipmentObjectSO];
    EquipmentObject.SpawnEquipmentObject(equipmentObjectSO, this);
    // GetEquipmentObjectCountWhichCarried();

    OnPlayerInteractTreasureChest?.Invoke(this, EventArgs.Empty);
  }
  // public int GetEquipmentObjectCountWhichCarried()
  // {
  //   int equipmentObjectCountWhichCarried = transform.Find(EQUIPMENT_OBJECT_DROP_POINT).childCount;
  //   Debug.Log("equipmentObjectCountWhichCarried: " + equipmentObjectCountWhichCarried);
  //   return equipmentObjectCountWhichCarried;
  // }
  // public List<Transform> GetEquipmentObjectListWhichCarried(int equipmentObjectCountWhichCarried)
  // {
  //   List<Transform> equipmentObjectListWhichCarried = new List<Transform>();
  //   for (int index = 0; index < equipmentObjectCountWhichCarried; index++)
  //   {
  //     equipmentObjectListWhichCarried.Add(transform.Find(EQUIPMENT_OBJECT_DROP_POINT).GetChild(index));
  //   }
  //   return equipmentObjectListWhichCarried;
  // }

}
