using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 20;
    public List<Item> items = new List<Item>();
    public event System.Action InventoryChangedEvent;

    public bool Add(Item item)
    {
        if (item.isDefaultItem) return true;
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }
        items.Add(item);
        InventoryChangedEvent?.Invoke();
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        InventoryChangedEvent?.Invoke();
    }
}
