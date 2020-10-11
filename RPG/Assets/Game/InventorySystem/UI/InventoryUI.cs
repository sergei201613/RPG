using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public Inventory inventory = null;
    public GameObject inventoryUI;

    private InventorySlot[] slots;


    private void Awake()
    {
        if (inventory == null)
        {
            inventory = FindObjectOfType<PlayerController>().GetComponent<Inventory>();
        }

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        foreach (var slot in slots)
        {
            slot.inventory = inventory;
        }

        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    private void OnEnable()
    {
        inventory.InventoryChangedEvent += UpdateUI;
    }

    private void OnDisable()
    {
        inventory.InventoryChangedEvent -= UpdateUI;
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {            
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
