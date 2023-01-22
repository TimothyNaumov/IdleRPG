using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyPopup : MonoBehaviour
{
    Rigidbody2D rb;
    TextMeshProUGUI thisText;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(Vector2.up * 75);
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        thisText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Color newColor = thisText.color;
        newColor.a -= .005f;
        if(newColor.a <= 0)
        {
            Destroy(gameObject);
        }
        thisText.color = newColor;
    }
}
