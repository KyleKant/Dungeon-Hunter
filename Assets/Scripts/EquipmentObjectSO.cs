using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentObjectSO", menuName = "Dungeon-Hunter/EquipmentObjectSO", order = 0)]
public class EquipmentObjectSO : ScriptableObject
{
  public Transform prefab;
  public Sprite sprite;
  public string objectName;
}
