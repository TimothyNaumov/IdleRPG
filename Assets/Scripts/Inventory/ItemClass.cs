using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class ItemClass : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int itemPrice;
    public bool isStackable = true;

    public abstract ItemClass GetItem();
    public abstract ConsumableClass GetConsumable();
    public abstract MiscClass GetMisc();
    public abstract ToolClass GetTool();
}
