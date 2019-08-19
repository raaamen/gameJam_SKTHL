using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerMovement : MonoBehaviour {

    public Vector3 upSpd;
    public Vector3 downSpd;
    public Vector3 leftSpd;
    public Vector3 rightSpd;

    public GameObject trash;
   

    public bool holdingTrash;

	// Use this for initialization
	void Start () {
        holdingTrash = false;
	}
	
	// Update is called once per frame
	void Update () {

        //player movement is WASD

        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Transform>().position += upSpd;
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Transform>().position += leftSpd;
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Transform>().position += downSpd;
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Transform>().position += rightSpd;
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
                    GetComponent<scr_playerInv>().addRecycle();
                    Destroy(collision.gameObject);
                    break;
            }
            Debug.Log("Trash collected");
        }
        if (collision.gameObject.name.Equals("obj_trashCan"))
        {
            //all trash deposited
            GetComponent<scr_playerInv>().depositAllTrash();
            holdingTrash = false;

        }
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
    }

}
