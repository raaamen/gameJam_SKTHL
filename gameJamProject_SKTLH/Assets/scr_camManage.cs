using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_camManage : MonoBehaviour {

    public bool isOutside;
    public bool isInPizzaShop;
    public bool isInArcade;
    public bool isInPool;
    public bool isHome;

    public Vector3 outsidePos;
    public Vector3 pizzaPos;
    public Vector3 arcadePos;
    public Vector3 poolPos;
    public Vector3 homePos;
    public Vector3 camPosPlayer;

    public string currentArea;

    public GameObject outsidePlayer;
    public GameObject mainCam;
    

	// Use this for initialization
	void Start () {
        currentArea = "Outside";
	}
	
	// Update is called once per frame
	void Update () {


        switch (currentArea)
        {
            case "Outside":
                mainCam.GetComponent<Camera>().orthographicSize = 3.7f;
                outsidePlayer.SetActive(true);
                isOutside = true;
                isInPool = false;
                isHome = false;
                isInArcade = false;
                isInPizzaShop = false;
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[0];
                GetComponent<GameManager>().bgmsrc.Play();


                //cam follow script

                camPosPlayer = new Vector3(outsidePlayer.GetComponent<Transform>().position.x, outsidePlayer.GetComponent<Transform>().position.y, -10f);

                mainCam.GetComponent<Transform>().position = camPosPlayer;



                break;
            case "PizzaParlor":


                isOutside = false;
                isInPool = false;
                isHome = false;
                isInArcade = false;
                isInPizzaShop = true;
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[1];
                GetComponent<GameManager>().bgmsrc.Play();
                mainCam.GetComponent<Transform>().position = pizzaPos;

                break;
            case "Arcade":


                isOutside = false;
                isInPool = false;
                isHome = false;
                isInArcade = true;
                isInPizzaShop = false;
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[2];
                GetComponent<GameManager>().bgmsrc.Play();
                mainCam.GetComponent<Transform>().position = arcadePos;

                break;
            case "Pool":

                isOutside = false;
                isInPool = true;
                isHome = false;
                isInArcade = false;
                isInPizzaShop = false;
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[3];
                GetComponent<GameManager>().bgmsrc.Play();
                mainCam.GetComponent<Transform>().position = poolPos;

                break;
            case "Home":


                isOutside = false;
                isInPool = false;
                isHome = true;
                isInArcade = false;
                isInPizzaShop = false;
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[4];
                GetComponent<GameManager>().bgmsrc.Play();
                mainCam.GetComponent<Transform>().position = homePos;



                break;
        }

    }
}
