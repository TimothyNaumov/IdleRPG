using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;
    public static InventoryManager Instance { get { return _instance; } }

    //Inventory Stock variables
    private int foodStock;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        foodStock = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isFoodInStock()
    {
        Debug.Log("Food in stock is " + foodStock);
        return foodStock > 0;
    }

    public void addFoodToStock()
    {
        foodStock++;
    }

    public void removeFoodFromStock()
    {
        foodStock--;
        Debug.Log("Food in stock has been removed to become " + foodStock);
    }
}
