using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestAnimator : MonoBehaviour
{
  private const string OPEN_CLOSE = "OpenClose";
  [SerializeField] private TreasureChest treasureChest;
  private Animator animator;
  private void Awake()
  {
    animator = GetComponent<Animator>();
  }
  private void Start()
  {
    treasureChest.OnPlayerInteractTreasureChest += TreasureChest_OnPlayerInteractTreasureChest;
  }
  private void TreasureChest_OnPlayerInteractTreasureChest(object sender, System.EventArgs e)
  {
    animator.SetTrigger(OPEN_CLOSE);
  }
}
