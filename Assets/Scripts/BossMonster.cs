using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : BaseStorage
{
  [SerializeField] private ItemObjectSO[] itemObjectSOs;
  private ItemObjectSO itemObjectSO;
  private int randomItemObjectSO;

  public override void Interact(Player player)
  {
    randomItemObjectSO = Random.Range(0, itemObjectSOs.Length);
    itemObjectSO = itemObjectSOs[randomItemObjectSO];
    ItemController.SpawnItemObject(itemObjectSO, this);

  }
}

