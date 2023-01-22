using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; private set; }

    [SerializeField] private GameObject slotHolder;

    public List<SlotClass> items = new List<SlotClass>();

    private GameObject[] slots;

    public event Action OnStartFinished;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        //set all the slots
        for(int i = 0; i < slotHolder.transform.childCount; i++) {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }
        RefreshUI();
        Debug.Log("Invoking the on start finished!");
        OnStartFinished?.Invoke();
    }

    public void RefreshUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {

            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;
                if (items[i].GetItem().isStackable)
                {
                    slots[i].transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = items[i].GetQuantity().ToString();
                } else
                {
                    slots[i].transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                }
                
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            }
        }
        //GameDataManager.Instance.gameData.itemInventory = items;
    }

    public bool Add(ItemClass item)
    {
        //check if inventory contains item
        SlotClass slot = Contains(item);
        if (slot != null && slot.GetItem().isStackable)
        {
            slot.AddQuantity(1);
        } else {
            if(items.Count < slots.Length)
            {
                items.Add(new SlotClass(item, 1));
            } else {
                return false;
            }
        }
        RefreshUI();
        return true;
    }

    public bool Remove(ItemClass item)
    {
        SlotClass slotToRemove = new SlotClass();
        SlotClass temp = Contains(item);
        if(temp != null)
        {
            if(temp.GetQuantity() >= 1)
            {
                temp.SubQuantity(1);
            } else
            {
                foreach (SlotClass slot in items)
                {
                    if (slot.GetItem() == item)
                    {
                        slotToRemove = slot;
                        break;
                    }
                }
                items.Remove(slotToRemove);
            }
            
        } else {
            return false;
        }
        RefreshUI();
        return true;
    }

    public SlotClass Contains(ItemClass item)
    {
        foreach(SlotClass slot in items)
        {
            if(slot.GetItem() == item)
            {
                return slot;
            }
        }

        return null;
    }

    private void OnApplicationQuit()
    {
        //GameDataManager.Instance.gameData.itemInventory = items;
    }
}
