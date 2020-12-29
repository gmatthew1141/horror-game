using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 20;

    #region Singleton
    public static Inventory instance;

    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than 1 instance of inventory is found");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback; 

    public List<ItemDetails> items = new List<ItemDetails>();

    public bool AddItem(ItemDetails item) {
        if (items.Count == space) {
            Debug.Log("No space in inventory");
            // ToDo: tell player inventory is full
            return false;
        }

        items.Add(item);

        if (onItemChangeCallback != null) {
            onItemChangeCallback.Invoke();
        }

        return true;
    }

    public void RemoveItem(ItemDetails item) {
        items.Remove(item);

        if (onItemChangeCallback != null) {
            onItemChangeCallback.Invoke();
        }
    }
}
