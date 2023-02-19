using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : BaseStorage
{
  public event EventHandler OnPlayerInteractTreasureChest;
  [SerializeField] private ItemObjectSO[] itemObjectSOs;
  private ItemObjectSO itemObjectSO;
  private int randomItemObjectSO;


  public override void Interact(Player player)
  {
    randomItemObjectSO = UnityEngine.Random.Range(0, itemObjectSOs.Length);
    itemObjectSO = itemObjectSOs[randomItemObjectSO];
    ItemController.SpawnItemObject(itemObjectSO, this);
    OnPlayerInteractTreasureChest?.Invoke(this, EventArgs.Empty);
  }
}
