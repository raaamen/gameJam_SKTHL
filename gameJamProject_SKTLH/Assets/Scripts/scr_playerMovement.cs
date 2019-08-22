using System.Collections;
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
    public GameObject pool;
    

    public Sprite poolClean;
    public Sprite arcadeClean;
    public Sprite pizzaClean;

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


        if (collision.gameObject==pool && Input.GetKeyDown(KeyCode.Space))
        {

            pool.GetComponent<SpriteRenderer>().sprite = poolClean;
            SFX.GetComponent<AudioSource>().clip = audioClipsSFX[4];
            SFX.GetComponent<AudioSource>().Play();
            gameManager.GetComponent<GameManager>().poolClean = true;

        }
        if (collision.gameObject.tag == "arcadeMachine" && Input.GetKeyDown(KeyCode.Space))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = arcadeClean;
            SFX.GetComponent<AudioSource>().clip = audioClipsSFX[4];
            SFX.GetComponent<AudioSource>().Play();
            gameManager.GetComponent<GameManager>().arcadeMachines2Clean--;
        }
        if (collision.gameObject.tag =="pizzaTable" && Input.GetKeyDown(KeyCode.Space))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = pizzaClean;
            SFX.GetComponent<AudioSource>().clip = audioClipsSFX[4];
            SFX.GetComponent<AudioSource>().Play();
            gameManager.GetComponent<GameManager>().pizzaTables2Clean--;
            Debug.Log(gameManager.GetComponent<GameManager>().pizzaTables2Clean);
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
       // Debug.Log(collision.gameObject.name);
        switch (collision.gameObject.name)
        {
            case "pizzaCollider":
                gameManager.GetComponent<scr_camManage>().currentArea = "PizzaParlor";
                changePos(1);
                break;
            case "poolCollider":
                gameManager.GetComponent<scr_camManage>().currentArea = "Pool";
                break;
            case "homeCollider":
                gameManager.GetComponent<scr_camManage>().currentArea = "Home";
                changePos(0);
                break;
            case "arcadeCollider":
                gameManager.GetComponent<scr_camManage>().currentArea = "Arcade";
                changePos(2);
                break;
            case "outsideColliderHome":
                gameManager.GetComponent<scr_camManage>().currentArea = "Outside";
                changePos(3);
                break;
            case "outsideColliderPizza":
                gameManager.GetComponent<scr_camManage>().currentArea = "Outside";
                changePos(4);
                break;
            case "outsideColliderArcade":
                gameManager.GetComponent<scr_camManage>().currentArea = "Outside";
                changePos(5);
                break;
        }
        if (collision.gameObject.tag == "trashCan")
        {
            //name
            gameManager.GetComponent<scr_playerInv>().depositAllTrash();
            if (holdingTrash)
            {
                SFX.GetComponent<AudioSource>().clip = audioClipsSFX[2];
                SFX.GetComponent<AudioSource>().Play();
            }
            holdingTrash = false;
            invFull = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
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

        if (collision.gameObject.tag == "YellowMember" && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("boop");
            collision.gameObject.GetComponent<dialogueFaction>().sayDialogue();
        }
    }

    public void changePos(int pos)
    {
        switch (pos)
        {
            case 0:
                GetComponent<Transform>().position = gameManager.GetComponent<scr_camManage>().homePos;
                break;
            case 1:
                GetComponent<Transform>().position = gameManager.GetComponent<scr_camManage>().pizzaPos;
                break;
            case 2:
                GetComponent<Transform>().position = gameManager.GetComponent<scr_camManage>().arcadePos;
                break;
            case 3:
                GetComponent<Transform>().position = gameManager.GetComponent<scr_camManage>().outsidePosHome;
                break;
            case 4:
                GetComponent<Transform>().position = gameManager.GetComponent<scr_camManage>().outsidePosPizza;
                break;
            case 5:
                GetComponent<Transform>().position = gameManager.GetComponent<scr_camManage>().outsidePosArcade;
                break;
        }
    }

}
