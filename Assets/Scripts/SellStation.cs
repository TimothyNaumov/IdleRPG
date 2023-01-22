using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellStation : MonoBehaviour
{
    
    private bool playerIsInRange = false;

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
        if (Input.GetButtonDown("Interact") && playerIsInRange)
        {
            Debug.Log("Shop is now open");
        }
    }
    
}
