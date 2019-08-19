using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject playerObj;
    public GameObject trashObj;

    public int gameTimer;
    public int totalTrash;

    public AudioClip[] bgm;
    public AudioClip[] sfx;

    public AudioSource bgmsrc;
    public AudioSource sfxsrc;

    public bool hasWon;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {

        if (totalTrash == 0)
        {
            hasWon = true;
            //win condition
        }



    }

    //trash spawns randomly in the outside world
    //inside, they are in dedicated positions
    //once all garbage is gone, win condition
    //roadblocks to block way

    public void initTrash()
    {

    }
   
}
