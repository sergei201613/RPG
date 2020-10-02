using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    
    public override void Interact(GameObject interactedCharacter)
    {
        var inventory = interactedCharacter.GetComponent<Inventory>();
        Pickup(inventory);
    }

    private void Pickup(Inventory inventory)
    {
        if (inventory == null) return;
        
        if (inventory.Add(item))
            Destroy(gameObject);
    }
}
