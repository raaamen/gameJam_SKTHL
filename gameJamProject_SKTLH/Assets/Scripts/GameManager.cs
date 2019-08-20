using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject playerObj;
    public GameObject trashObj;
    public GameObject winScreen;

    public int totalTrash;

    public AudioClip[] bgm;
    public AudioClip[] sfx;

    public AudioSource bgmsrc;
    public AudioSource sfxsrc;

    public bool hasWon;
    public bool titleOnScreen;

	// Use this for initialization
	void Start () {
        totalTrash = 1;
        initTrash();
	}
	
	// Update is called once per frame
	void Update () {

        if (totalTrash == 0)
        {
            hasWon = true;
            winScreen.SetActive(true);

            //win condition
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
