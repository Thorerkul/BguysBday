using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    new public TextMeshProUGUI name;
    public InventoryUI ui;

    Item item;

    private void Start()
    {
        clearSlot();
        ui.UpdateUI();
    }

    private void Awake()
    {
        ui.UpdateUI();
    }

    public void addItem(Item newItem)
    {
        item = newItem;

        name.text = newItem.itemName;

        icon.sprite = newItem.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    } 

    public void clearSlot()
    {
        item = null;

        name.text = "";

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void onRemoveButton()
    {
        Inventory.Instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
