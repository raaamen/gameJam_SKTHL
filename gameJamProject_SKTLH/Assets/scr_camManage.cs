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

    public string currentArea;

    public GameObject outsidePlayer;
    public GameObject mainCam;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        switch (currentArea)
        {
            case "Outside":
                outsidePlayer.SetActive(true);
                isOutside = true;
                isInPool = false;
                isHome = false;
                isInArcade = false;
                isInPizzaShop = false;

                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[0];

                mainCam.GetComponent<Transform>().position = outsidePos;

                break;
            case "PizzaParlor":


                isOutside = false;
                isInPool = false;
                isHome = false;
                isInArcade = false;
                isInPizzaShop = true;

                mainCam.GetComponent<Transform>().position = pizzaPos;

                break;
            case "Arcade":


                isOutside = false;
                isInPool = false;
                isHome = false;
                isInArcade = true;
                isInPizzaShop = false;

                mainCam.GetComponent<Transform>().position = arcadePos;

                break;
            case "Pool":

                isOutside = false;
                isInPool = true;
                isHome = false;
                isInArcade = false;
                isInPizzaShop = false;

                mainCam.GetComponent<Transform>().position = poolPos;

                break;
            case "Home":


                isOutside = false;
                isInPool = false;
                isHome = true;
                isInArcade = false;
                isInPizzaShop = false;

                mainCam.GetComponent<Transform>().position = homePos;

                break;
        }

    }
}
