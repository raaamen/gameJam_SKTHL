﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerMovement : MonoBehaviour {

    public Vector3 upSpd;
    public Vector3 downSpd;
    public Vector3 leftSpd;
    public Vector3 rightSpd;
    public Vector3 pizzaSpawn;
    public Vector3 poolSpawn;
    public Vector3 arcadeSpawn;
    public Vector3 homeSpawn;
    public Vector3 flipXA;
    public Vector3 flipXD;

    public GameObject trash;
    public GameObject gameManager;

    public bool holdingTrash;
    public bool invFull;

    public AudioSource SFX;

    public AudioClip[] audioClipsSFX;

	// Use this for initialization
	void Start () {
        holdingTrash = false;
        
	}
	
	// Update is called once per frame
	void Update () {

        //player movement is WASD
        if (isActiveAndEnabled) {

            if (Input.GetKey(KeyCode.W))
            {
                GetComponent<Transform>().position += upSpd;
                switch (holdingTrash)
                {
                    case false:
                        GetComponent<Animator>().Play("plrWalk");
                        break;
                    case true:
                        GetComponent<Animator>().Play("plrWalkCarry");
                        break;
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Transform>().position += leftSpd;
                GetComponent<Transform>().localScale = flipXA;
                switch (holdingTrash)
                {
                    case false:
                        GetComponent<Animator>().Play("plrWalk");
                        break;
                    case true:
                        GetComponent<Animator>().Play("plrWalkCarry");
                        break;
                }

            }
            else if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Transform>().position += downSpd;
                switch (holdingTrash)
                {
                    case false:
                        GetComponent<Animator>().Play("plrWalk");
                        break;
                    case true:
                        GetComponent<Animator>().Play("plrWalkCarry");
                        break;
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Transform>().position += rightSpd;
                GetComponent<Transform>().localScale = flipXD;
                switch (holdingTrash)
                {
                    case false:
                        GetComponent<Animator>().Play("plrWalk");
                        break;
                    case true:
                        GetComponent<Animator>().Play("plrWalkCarry");
                        break;
                }
            }
            else
            {

                switch (holdingTrash)
                {
                    case false:
                        GetComponent<Animator>().Play("plrIdle");
                        break;
                    case true:
                        GetComponent<Animator>().Play("plrIdleCarry");
                        break;
                }
            }
        }


        //trash is picked up oncollision and pressing spacebar

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trash" && Input.GetKeyDown(KeyCode.Space))
        {
            if (holdingTrash == false)
            {
                holdingTrash = true;
            }

            switch (holdingTrash)
            {
                case false:
                    //switch sprite to holding
                    holdingTrash = true;
                    Destroy(collision.gameObject);
                    break;
                case true:
                    gameManager.GetComponent<scr_playerInv>().addRecycle();
                    if (!invFull)
                    {
                        SFX.GetComponent<AudioSource>().clip = audioClipsSFX[1];
                        SFX.GetComponent<AudioSource>().Play();
                        Destroy(collision.gameObject);
                    }
                    break;
            }
            Debug.Log("Trash collected");
        }




        /*
        if (collision.gameObject.tag == "ArcadeMachine")
        {

        }
        if (collision.gameObject.tag == "Pool")
        {

        }
        if (collision.gameObject.tag == "Table")
        {

        }
        if (collision.gameObject.tag == "ArcadeMachine")
        {

        }
        */  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "pizzaCollider":
                GetComponent<scr_camManage>().currentArea = "PizzaParlor";
                break;
            case "poolCollider":
                GetComponent<scr_camManage>().currentArea = "Pool";
                break;
            case "homeCollider":
                GetComponent<scr_camManage>().currentArea = "Home";
                break;
            case "arcadeCollider":
                GetComponent<scr_camManage>().currentArea = "Arcade";
                break;
            case "outsideCollider":
                GetComponent<scr_camManage>().currentArea = "Outside";
                break;
        }
        if (collision.gameObject.name.Equals("obj_trashCan"))
        {
            gameManager.GetComponent<scr_playerInv>().depositAllTrash();
            SFX.GetComponent<AudioSource>().clip = audioClipsSFX[2];
            SFX.GetComponent<AudioSource>().Play();
            holdingTrash = false;
            invFull = false;
        }
    }

}
