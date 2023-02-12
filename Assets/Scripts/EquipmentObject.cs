using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentObject : BaseStorage
{
  [SerializeField] private EquipmentObjectSO equipmentObjectSO;

  public IEquipmentObjectParent equipmentObjectParent;


  public EquipmentObjectSO GetEquipmentObjectSO()
  {
    return equipmentObjectSO;
  }

  public void SetEquipmentObjectParent(IEquipmentObjectParent equipmentObjectParent)
  {
    if (this.equipmentObjectParent != null)
    {
      this.equipmentObjectParent.ClearEquipmentObject();
      // Debug.Log("equipmentParent: " + this.equipmentObjectParent);
    }
    this.equipmentObjectParent = equipmentObjectParent;
    // if (equipmentObjectParent.HasEquipmentObject() )
    // {
    //   Debug.LogError(equipmentObjectParent + " already has a equipmentObject");
    // }
    equipmentObjectParent.SetEquipmentObject(this);

    transform.parent = equipmentObjectParent.GetEquipmentObjectFollowTransform();
    transform.localPosition = Vector3.zero;
  }

  public IEquipmentObjectParent GetEquipmentObjectParent()
  {
    return equipmentObjectParent;
  }

  public override void Interact(Player player)
  {
    if (!HasEquipmentObject())
    {
      // Transform equipmentObjectTransform = Instantiate(equipmentObjectSO.prefab);
      SetEquipmentObjectParent(player);
    }
    // else
    // {
    //   // equipmentObject.SetTreasureChest(secondTreasureChest);
    //   equipmentObject.SetEquipmentObjectParent(player);
    //   // Debug.Log("equipmentObjectHoldPoint:" + GetEquipmentObjectFollowTransform().localPosition);
    //   // Debug.Log(equipmentObject.GetTreasureChest());
    // }
  }

  public void DestroySelf()
  {
    equipmentObjectParent.ClearEquipmentObject();
    Destroy(gameObject);
  }
  public static EquipmentObject SpawnEquipmentObject(EquipmentObjectSO equipmentObjectSO, IEquipmentObjectParent equipmentObjectParent)
  {
    Transform equipmentObjectTransform = Instantiate(equipmentObjectSO.prefab);
    EquipmentObject equipmentObject = equipmentObjectTransform.GetComponent<EquipmentObject>();
    equipmentObject.SetEquipmentObjectParent(equipmentObjectParent);
    return equipmentObject;
  }
}
