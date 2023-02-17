using System.Runtime.Serialization;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
  public static InventoryManager Instance;
  public List<ItemObjectSO> items = new List<ItemObjectSO>();
  public Transform itemContent;
  [SerializeField] private GameObject inventoryItem;

  private void Awake()
  {
    Instance = this;
  }
  public void AddItem(ItemObjectSO itemObjectSO)
  {
    items.Add(itemObjectSO);
  }
  public void RemoveItem(ItemObjectSO itemObjectSO)
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
      Debug.Log(obj.transform.Find("ItemName").GetComponent<Text>());
      var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
      itemName.text = item.itemName;
      itemIcon.sprite = item.itemIcon;
    }
  }
}
