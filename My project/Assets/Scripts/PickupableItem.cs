using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : MonoBehaviour
{
    public Item item;
    public Collider col;

    public void Pickup()
    {
        bool wasPickedUp = Inventory.Instance.Add(item);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
