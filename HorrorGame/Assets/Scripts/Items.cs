using UnityEngine;

public class Items : Interactable {

    public ItemDetails details;
    public override void Interacted() {
        base.Interacted();

        Debug.Log("Interacting with an item");
        // need to check if the item is obtainable or not
        // if its obtainable, add to inventory
        // if its not obtainable, show dialog about the item
        if (transform.tag == "ObtainableItem") {
            if (!hasInteracted) {               // make sure obtainable item added to inventory once
                hasInteracted = true;
                Pickup();
            }
        } else {

        }
    }

    private void Pickup() {
        Debug.Log("Item picked up");
        bool wasPicked = Inventory.instance.AddItem(details);

        if (wasPicked) {
            Debug.Log(details.name + " was picked up");
            Destroy(gameObject);
        }    
    }
}
