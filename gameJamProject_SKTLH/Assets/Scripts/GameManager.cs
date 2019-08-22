﻿using System.Collections;
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

    public AudioClip[] bgm;
    public AudioClip[] sfx;

    public AudioSource bgmsrc;
    public AudioSource sfxsrc;

    public bool hasWon;
    public bool titleOnScreen;
    public bool everythingClean;
    public bool poolClean;

	// Use this for initialization
	void Start () {
        totalTrash = GameObject.FindGameObjectsWithTag("Trash").Length;
        initTrash();
        arcadeMachines2Clean = 9;
	}
	
	// Update is called once per frame
	void Update () {

        if (totalTrash == 0 && everythingClean)
        {
            hasWon = true;
            winScreen.SetActive(true);
            GetComponent<scr_camManage>().currentArea = "Win";
            //win condition
        }

        if (poolClean && arcadeMachines2Clean == 0)
        {
            everythingClean = true;
        }

    }

    //trash spawns randomly in the outside world
    //inside, they are in dedicated positions
    //once all garbage is gone, win condition
    //roadblocks to block way

    public void initTrash()
    {

        for (int i = 0; i < 11; i++)
        {
            //Instantiate at positions
            //int x = Random.Range();
            Vector3 vec = new Vector3();

        }
        for (int i = 0; i < 11; i++)
        {

        }
        for (int i = 0; i < 11; i++)
        {

        }
        for (int i = 0; i < 11; i++)
        {

        }
        for (int i = 0; i < 11; i++)
        {

        }




    }

}
