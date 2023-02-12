using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : BaseStorage
{
  [SerializeField] private EquipmentObjectSO[] equipmentObjectSOArray;
  private EquipmentObjectSO equipmentObjectSO;
  private int randomEquipmentObjectSO;

  public override void Interact(Player player)
  {
    randomEquipmentObjectSO = Random.Range(0, equipmentObjectSOArray.Length);
    equipmentObjectSO = equipmentObjectSOArray[randomEquipmentObjectSO];
    EquipmentObject.SpawnEquipmentObject(equipmentObjectSO, this);
    // Transform equipmentObjectTransform = Instantiate(equipmentObjectSO.prefab);
    // equipmentObjectTransform.GetComponent<EquipmentObject>().SetEquipmentObjectParent(this);

  }
}

