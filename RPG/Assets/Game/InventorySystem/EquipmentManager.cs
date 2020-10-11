using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class EquipmentManager : MonoBehaviour
{
    public delegate void EquipmentChanged(Equipment newItem, Equipment oldItem);
    public event EquipmentChanged equipmentChangedEvent;

    private Equipment[] _equipment;
    private Inventory _inventory;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        _equipment = new Equipment[numSlots];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }

    public void Equip(Equipment newEquipment)
    {
        int slotIndex = (int)newEquipment.equipSlot;

        Equipment oldItem = null;

        if (_equipment[slotIndex] != null)
        {
            oldItem = _equipment[slotIndex];
            _inventory.Add(oldItem);
        }

        equipmentChangedEvent?.Invoke(newEquipment, oldItem);

        _equipment[slotIndex] = newEquipment;
    }

    public void Unequip(int slotIndex)
    {
        if (_equipment[slotIndex] == null) return;

        Equipment oldItem = _equipment[slotIndex];

        _inventory.Add(oldItem);
        _equipment[slotIndex] = null;

        equipmentChangedEvent?.Invoke(null, oldItem);
    }

    public void UnequipAll()
    {
        for (int i = 0; i < _equipment.Length; i++)
        {
            Unequip(i);
        }
    }
}
