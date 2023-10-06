using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public int buyValue = 1;
    public int sellValue = 1;
    public bool isEquipable = false;

    public virtual void Use()
    {
        // SOmethimg happen
        Debug.Log("Using " + name);
    }
}
