using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject playerObj;
    public GameObject trashObj;
    public GameObject winScreen;
    public GameObject roadblockPizza;
    public GameObject roadblockArcade;

    public int totalTrash;
    public int arcadeMachines2Clean;
    public int pizzaTables2Clean;

    public AudioClip[] bgm;
    public AudioClip[] sfx;

    public AudioSource bgmsrc;
    public AudioSource sfxsrc;

    public bool hasWon;
    public bool titleOnScreen;
    public bool everythingClean;
    public bool poolClean;
    public bool arcadeClean;
    public bool pizzaClean;

    public Text trashLeftText;
    public Text toCleanText;

	// Use this for initialization
	void Start () {
        totalTrash = GameObject.FindGameObjectsWithTag("Trash").Length;
        arcadeMachines2Clean = 9;
        pizzaTables2Clean = 2;
        everythingClean = false;
	}
	
	// Update is called once per frame
	void Update () {

        toCleanText.text = "Clean the pool, arcade machines, and pizza tables!";



        trashLeftText.text = "Trash Remaining: "+totalTrash;

        if (totalTrash <= 24)
        {
            roadblockPizza.SetActive(false);
            roadblockArcade.SetActive(false);
        }

        if (totalTrash == 0 && everythingClean)
        {
            hasWon = true;
            winScreen.SetActive(true);
            GetComponent<scr_camManage>().currentArea = "Win";
            //win condition
        }

        if (poolClean && arcadeClean && pizzaClean)
        {
            everythingClean = true;
        }
        if (arcadeMachines2Clean == 0)
        {
            arcadeClean = true;
        }
        if (pizzaTables2Clean==0)
        {
            pizzaClean = true;
        }

    }

    //trash spawns randomly in the outside world
    //inside, they are in dedicated positions
    //once all garbage is gone, win condition
    //roadblocks to block way

    

}
