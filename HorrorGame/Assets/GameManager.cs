using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject inventoryUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            OpenInventory();
        }
    }

    private void OpenInventory() {
        if (inventoryUI.activeSelf) {
            inventoryUI.SetActive(false);
        } else {
            inventoryUI.SetActive(true);
        }
        
    }
}
