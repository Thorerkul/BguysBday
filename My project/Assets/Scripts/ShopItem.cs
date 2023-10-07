using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Shop shop;
    public Item item;
    public Image icon;
    public TextMeshProUGUI text;
    public TextMeshProUGUI price;

    private void Awake()
    {
        icon.sprite = item.icon;
        if (item.isObtainable)
        {
            text.text = item.itemName;
            price.text = item.buyValue.ToString() + " GM";
        } else
        {
            text.text = "";
            price.text = "";
        }
    }

    public void ClearItem()
    {
        icon.sprite = null;
        icon.enabled = false;
        text.text = "";
        price.text = "";
    }

    public void Purchase()
    {
        shop.Purchace(item, this);
        ClearItem();
    }
}
