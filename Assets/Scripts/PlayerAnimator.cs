using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
  private const string IS_IDLE = "IsIdle";
  private const string IS_RUNNING = "IsRunning";
  private const string IS_WALKING = "IsWalking";
  private const string IS_NORMAL_ATTACK_01 = "IsNormalAttack01";
  private const string IS_NORMAL_ATTACK_02 = "IsNormalAttack02";
  [SerializeField] private Player player;
  private Animator animator;
  private void Awake()
  {
    animator = GetComponent<Animator>();
  }
  private void Update()
  {
    animator.SetBool(IS_RUNNING, player.IsRunning());
    animator.SetBool(IS_WALKING, player.IsWalking());
    animator.SetBool(IS_IDLE, player.IsIdle());
    animator.SetBool(IS_NORMAL_ATTACK_01, player.IsNormalAttack01());
    animator.SetBool(IS_NORMAL_ATTACK_02, player.IsNormalAttack02());

    // Debug.Log("Player is running:" + player.IsRunning());
  }
}
