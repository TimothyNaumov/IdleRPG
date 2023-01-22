using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PopulateItems : MonoBehaviour
{
    public ItemClass[] items;

    private void Start() {
        InventoryController.Instance.OnStartFinished += addItems;
    }

    public void addItems() {
        foreach (ItemClass item in items) {
            InventoryController.Instance.Add(item);
        }
    }
}
