using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCard : MonoBehaviour
{
    public void setupItem(Sprite itemIcon, string title, string price) {
        Image image = transform.Find("Image").GetComponent<Image>();
        image.sprite = itemIcon;
        Text titleText = transform.Find("Title").GetComponent<Text>();
        titleText.text = title;
        Text priceText = transform.Find("Price").GetComponent<Text>();
        priceText.text = price;
    }
}
