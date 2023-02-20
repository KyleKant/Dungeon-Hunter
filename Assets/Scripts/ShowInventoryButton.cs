using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInventoryButton : MonoBehaviour
{
  [SerializeField] private GameInput gameInput;
  [SerializeField] private GameObject inventory;
  private bool toggleInventory;
  private void Start()
  {
    gameInput.OnToggleInventoryAction += GameInput_OnToggleInventoryAction;
  }
  private void Update()
  {
    toggleInventory = inventory.activeSelf;
  }
  private void GameInput_OnToggleInventoryAction(object sender, System.EventArgs e)
  {
    toggleInventory = !toggleInventory;
    this.GetComponentInParent<Canvas>().transform.Find("Inventory").gameObject.SetActive(toggleInventory);
    this.GetComponentInParent<Canvas>().GetComponentInParent<SystemUIs>().GetComponentInChildren<InventoryManager>().ListItems();
  }
}
