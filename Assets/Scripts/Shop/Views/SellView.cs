using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellView : MonoBehaviour
{
    private List<SlotClass> items;
    public GameObject shopItem;
    private void Awake() {
        if(InventoryController.Instance == null) {
            Debug.LogError("Sell View can't find Inventory Controller Instance");
        }
        items = InventoryController.Instance.items;
        Debug.Log("There are " + items.Count + " items in your inventory");
        addItemsToView();
    }

    private void addItemsToView() {
        foreach (SlotClass item in items) {
            ItemCard newSellItem = Instantiate(shopItem, transform).GetComponent<ItemCard>();
            newSellItem.setupItem(item.GetItem().itemIcon, item.GetItem().itemName, "" + item.GetItem().itemPrice);
        }
    }   
}
