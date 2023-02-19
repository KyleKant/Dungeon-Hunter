using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemObjectSO", menuName = "Dungeon-Hunter/ItemObjectSO/Create New ItemObjectSO")]
public class ItemObjectSO : ScriptableObject
{
  public int id;
  public Transform prefab;
  public string itemName;
  public int buffValue;
  public Sprite itemIcon;
}
