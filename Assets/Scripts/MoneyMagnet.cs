using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyMagnet : MonoBehaviour
{
    GameObject player;
    public GameObject mainCanvas;
    public GameObject moneyPopup;
    float distanceToPlayer;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCanvas = GameObject.Find("MainCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
            Debug.Log("Distance to player is " + distanceToPlayer);
            //.5
            if(distanceToPlayer <= .5f)
            {
                MoneyManager.Instance.increaseMoney();
                Instantiate(moneyPopup, transform.position, Quaternion.identity, mainCanvas.transform);
                Destroy(gameObject);
            }
            Vector2 vectorTowardsPlayer = player.transform.position - transform.position;
            rb.AddForce(vectorTowardsPlayer);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("MoneyPickupCollider"))
        {
            player = collision.gameObject;
            Debug.Log("Money has been collected by player!");
            //Destroy(gameObject);
        }
    }


}
