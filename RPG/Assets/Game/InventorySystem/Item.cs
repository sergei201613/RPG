﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public new string name = "New Name";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use(Inventory inventory)
    {
        Debug.Log("Using " + name);
    }
}
