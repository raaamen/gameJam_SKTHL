using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_camManage : MonoBehaviour
{

    public bool isOutside;
    public bool isInPizzaShop;
    public bool isInArcade;
    public bool isInPool;
    public bool isHome;

    public Vector3 outsidePosHome;
    public Vector3 outsidePosPizza;
    public Vector3 outsidePosArcade;
    public Vector3 pizzaPos;
    public Vector3 arcadePos;
    public Vector3 poolPos;
    public Vector3 homePos;
    public Vector3 camPosPlayer;

    public string currentArea;

    public GameObject outsidePlayer;
    public GameObject mainCam;
    public GameObject titleScreen;
    public GameObject pizzaBG;
    public GameObject arcadeBG;
    public GameObject homeBG;

    // Use this for initialization
    void Start()
    {
        currentArea = "Title";
    }

    // Update is called once per frame
    void Update()
    {
        homeBG.SetActive(false);
        pizzaBG.SetActive(false);
        arcadeBG.SetActive(false);
        camPosPlayer = new Vector3(outsidePlayer.GetComponent<Transform>().position.x, outsidePlayer.GetComponent<Transform>().position.y, -10f);
        mainCam.GetComponent<Transform>().position = camPosPlayer;
        if (!GetComponent<GameManager>().bgmsrc.isPlaying)
        {
            GetComponent<GameManager>().bgmsrc.Play();
        }
        switch (currentArea)
        {
            case "Title":
                titleScreen.SetActive(true);
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[5];
                break;
            case "Outside":
                mainCam.GetComponent<Camera>().orthographicSize = 4.5f;

                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[0];
                break;
            case "PizzaParlor":
                mainCam.GetComponent<Camera>().orthographicSize = 3.2f;
                pizzaBG.SetActive(true);
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[1];
                break;
            case "Arcade":
                mainCam.GetComponent<Camera>().orthographicSize = 3.2f;
                arcadeBG.SetActive(true);
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[2];
                break;
            case "Pool":
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[3];
                break;
            case "Home":
                mainCam.GetComponent<Camera>().orthographicSize = 3.2f;
                homeBG.SetActive(true);
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[4];
                break;
            case "Win":
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[6];
                break;
        }

    }

}
