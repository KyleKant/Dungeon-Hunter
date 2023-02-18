using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
  public static InventoryManager Instance;
  public List<ItemObjectSO> items = new List<ItemObjectSO>();
  private InventoryItemController[] inventoryItems;
  [SerializeField] private Transform itemContent;

  [SerializeField] private GameObject inventoryItem;
  [SerializeField] private Toggle enableRemove;

  private void Awake()
  {
    Instance = this;
  }
  public void Add(ItemObjectSO itemObjectSO)
  {
    items.Add(itemObjectSO);
  }
  public void Remove(ItemObjectSO itemObjectSO)
  {
    items.Remove(itemObjectSO);
  }
  public void ListItems()
  {
    foreach (Transform item in itemContent)
    {
      Destroy(item.gameObject);
    }
    foreach (var item in items)
    {
      GameObject obj = Instantiate(inventoryItem, itemContent);
      var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
      var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
      var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();
      Debug.Log(removeButton);
      itemName.text = item.itemName;
      itemIcon.sprite = item.itemIcon;
      if (enableRemove.isOn)
      {
        removeButton.gameObject.SetActive(true);
      }
    }
    SetInventoryItems();
  }
  public void EnableItemsRemove()
  {
    if (enableRemove.isOn)
    {
      foreach (Transform item in itemContent)
      {
        Debug.Log("item: " + item.Find("RemoveButton"));
        item.Find("RemoveButton").gameObject.SetActive(true);
      }
    }
    else
    {
      foreach (Transform item in itemContent)
      {
        item.Find("RemoveButton").gameObject.SetActive(false);
      }
    }
  }
  public void SetInventoryItems()
  {
    inventoryItems = itemContent.GetComponentsInChildren<InventoryItemController>();
    for (var i = 0; i < items.Count; i++)
    {
      inventoryItems[i].AddItem(items[i]);
    }
    {

    }
  }
}
