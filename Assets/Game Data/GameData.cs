using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameData
{
    public int money = 0;
    public int petFood = 1;
    public int petHunger = 50;
    public bool foodIsInBowl = true;

    public List<SlotClass> itemInventory = new List<SlotClass>();
    public List<NonScriptableItemClass> nonScriptableItems = new List<NonScriptableItemClass>();
}
