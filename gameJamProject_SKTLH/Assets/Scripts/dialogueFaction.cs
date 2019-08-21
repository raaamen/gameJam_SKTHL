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

    public bool countTime;

	// Use this for initialization
	void Start () {
        dialogueTimer = 0;
        countTime = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (dialoguePan.activeInHierarchy)
        {
            dialogueTimer += Time.deltaTime;
        }
        if (dialogueTimer >= 2)
        {
            dialogueTimer = 0;
            dialoguePan.SetActive(false);
        }


    }
    void decideDialogue()
    {
        dialogueChoice = (int)Random.Range(0, dialogueOptions.Length-1);
    }
    public void sayDialogue()
    {
        decideDialogue();
        dialoguePan.SetActive(true);
        dialogue.text = dialogueOptions[dialogueChoice];
    }
}
