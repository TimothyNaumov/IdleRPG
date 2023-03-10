using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Tool")]
public class ToolClass : ItemClass
{
    [Header("Tool")]
    public ToolType toolType;
    public enum ToolType
    {
        weapons,
        pickaxe,
        hammer,
        axe,
    }
    public override ItemClass GetItem() { return this; }

    public override ToolClass GetTool() { return this; }
    public override ConsumableClass GetConsumable() { return null; }
    public override MiscClass GetMisc() { return null; }

}
