using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : MonoBehaviour
{
    private bool playerIsInRange = false;
    [SerializeField] private ItemClass item;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "InteractionCollider")
        {
            playerIsInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "InteractionCollider")
        {
            playerIsInRange = false;
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Interact") && playerIsInRange)
        {
            InventoryController.Instance.Add(item);
            Destroy(this.gameObject);
        }
    }

    //public ItemClass GetItem() { return item; }
}
