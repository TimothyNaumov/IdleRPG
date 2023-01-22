using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHotbar : MonoBehaviour
{
    public List<GameObject> hotbar = new List<GameObject>();
    public GameObject InventoryItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject item = Instantiate(InventoryItem, transform);
            item.GetComponent<InventoryItem>().setSpaceNumber(i);
            hotbar.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
