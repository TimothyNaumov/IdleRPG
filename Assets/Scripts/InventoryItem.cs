using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    int spaceNumber;
    TextMeshProUGUI spaceNumberText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        spaceNumberText = transform.Find("Space Number").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSpaceNumber(int num)
    {
        spaceNumber = num;
        spaceNumberText.text = "" + spaceNumber;
    }
}
