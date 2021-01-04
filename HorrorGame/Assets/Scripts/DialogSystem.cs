using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : Interactable {

    public Dialog dialog;
    public Text nameText;
    public Text dialogText;
    public Image dialogImage;
    public GameObject dialogUI;
    public PlayerController player;

    private int currDialog;

    public override void Interacted() {
        // ToDo: disable player movement
        // ToDo: pause all timer (if any)
        player.AllowMovement(false);

        currDialog = 1;
        hasInteracted = true;
        dialogUI.SetActive(true);

        nameText.text = dialog.name[0];
        dialogText.text = dialog.texts[0];
        dialogImage.sprite = dialog.images[0];
    }

    // Update is called once per frame
    void Update() {
        if (!hasInteracted) {
            return;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)) {
            if (currDialog < dialog.name.Length) {
                nameText.text = dialog.name[currDialog];
                dialogText.text = dialog.texts[currDialog];
                dialogImage.sprite = dialog.images[currDialog];
                currDialog++;
            } else {
                EndDialog();
            }
        }
    }

    public void EndDialog() {
        dialogUI.SetActive(false);
        player.AllowMovement(true);
        // ToDo: enable player movement
        // ToDo: resume all timer
        if (!dialog.isRepeatable) {
            Destroy(gameObject);
        }
    }
}
