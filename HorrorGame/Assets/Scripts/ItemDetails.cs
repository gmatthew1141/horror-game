using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Item")]
public class ItemDetails : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
}
