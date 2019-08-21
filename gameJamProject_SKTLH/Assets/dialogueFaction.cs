using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueFaction : MonoBehaviour {

    public string[] dialogueOptions;

    public int dialogueChoice;

    public GameObject dialoguePan;
    public Text dialogue;

    public float dialogueTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



	}
    void decideDialogue()
    {
        dialogueChoice = (int)Random.Range(0, dialogueOptions.Length);
    }
    public void sayDialogue()
    {
        decideDialogue();
        dialoguePan.SetActive(true);
        dialogue.text = dialogueOptions[dialogueChoice];
    }
}
