using UnityEngine;

public class Doors : Interactable {

    public override void Interacted() {
        base.Interacted();

        Debug.Log("Interacting with a door");

        // player should enter/exit the room
    }
}
