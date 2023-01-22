using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Misc")]
public class MiscClass : ItemClass
{
    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return null; }
    public override ConsumableClass GetConsumable() { return null; }
    public override MiscClass GetMisc() { return this; }
}
