﻿using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    ItemDetails item;

    public void AddItem (ItemDetails newItem) {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot() {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
