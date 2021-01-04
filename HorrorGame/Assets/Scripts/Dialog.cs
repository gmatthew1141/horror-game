using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Dialog")]

public class Dialog : ScriptableObject {
    new public string[] name;
    [TextArea] public string dialogDescription;
    [TextArea] public string[] texts;
    public Sprite[] images;
    public bool isRepeatable = false;
}
