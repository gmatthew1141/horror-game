using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    private GameSettings gameSettings;
    private Vector2 dir;
    private bool canMove = true;

    // Interaction variables
    public Transform interactPointN;

    private void Awake() {
        gameSettings = FindObjectOfType<GameSettings>();
    }

    // Update is called once per frame
    void Update() {

        var xMove = Input.GetAxisRaw("Horizontal");
        var yMove = Input.GetAxisRaw("Vertical");

        dir = new Vector2(xMove, yMove);

        // need to update sprite position based on input
        
        if (yMove == 1) {
            // look up
        } else if (yMove == -1) {
            // look down
        } else if (xMove == 1) {
            // look left
        } else if (xMove == -1) {
            // look right
        }

        if (Input.GetButtonDown("Interact")) {
            Interact();
        }


    }

    private void FixedUpdate() {
        if (canMove) {
            transform.Translate(dir * gameSettings.moveSpeed * Time.deltaTime);
        }

    }

    private void Interact() {
        Quaternion stepAngle = Quaternion.AngleAxis(30, Vector3.forward);
        Vector3 direction = transform.rotation * Vector3.up;

        // cast raycast that detects items on all directions at 30 degrees interval
        for (int i = 0; i < 12; i++) {
            // raycast will ignore all layers other than "Interactables"
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, gameSettings.interactionRadius, 1 << LayerMask.NameToLayer("Interactables"));
            if (hit.collider) {
                Debug.Log("Hit2: " + hit.collider.name);
                Debug.DrawRay(transform.position, direction * gameSettings.interactionRadius, Color.red);

                var item = hit.collider.GetComponent<Interactable>();
                item.Interacted();

            } else {
                Debug.Log("Raycast did not interact with anything");
                Debug.DrawRay(transform.position, direction * gameSettings.interactionRadius, Color.white);
                // player should not do anything here
            }
            direction = stepAngle * direction;
        }
    }

    public void AllowMovement(bool allow) {
        canMove = allow;
    }

    private void OnDrawGizmos() {
        //float rad = gameSettings.interactionRadius;
            
        //Gizmos.DrawWireSphere(transform.position, rad);
    }


}
