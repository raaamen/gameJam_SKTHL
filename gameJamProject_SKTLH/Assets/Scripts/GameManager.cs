using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject playerObj;
    public GameObject trashObj;

    public int gameTimer;
    public int totalTrash;

    public bool hasWon;


	// Use this for initialization
	void Start () {
		
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
