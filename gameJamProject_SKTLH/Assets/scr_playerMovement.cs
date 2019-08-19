using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerMovement : MonoBehaviour {

    public Vector3 upSpd;
    public Vector3 downSpd;
    public Vector3 leftSpd;
    public Vector3 rightSpd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

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

    }
}
