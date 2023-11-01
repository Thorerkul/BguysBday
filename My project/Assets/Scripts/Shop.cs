using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using System.Linq;

public class Shop : MonoBehaviour
{
    public Transform[] itemRows;
    public List<InventorySlot> slots;
    public TextMeshProUGUI money;
    new public TextMeshProUGUI name;
    public string shopName;

    Inventory inventory;

    private void Awake()
    {
        inventory = Inventory.Instance;
        name.text = shopName;

        foreach (Transform row in itemRows)
        {
            foreach (InventorySlot slot in row.GetComponentsInChildren<InventorySlot>())
            {
                slots.Add(slot);
            }
        }
    }
    
    public void Purchace(Item item, ShopItem slot)
    {
        if (inventory.gamerMiles >= item.buyValue)
        {
            if (item.isObtainable)
            {
                inventory.Add(item);
                inventory.gamerMiles -= item.buyValue;
                money.text = inventory.gamerMiles.ToString();
            } else
            {
                Debug.Log("Not obtainable: " + item.name);
            }

        } else
        {
            Debug.Log("Not enough money for " + item.name + " Price: " + item.buyValue);
        }
    }

}
