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

    public Vector3 outsidePos;
    public Vector3 pizzaPos;
    public Vector3 arcadePos;
    public Vector3 poolPos;
    public Vector3 homePos;
    public Vector3 camPosPlayer;

    public string currentArea;

    public GameObject outsidePlayer;
    public GameObject mainCam;
    public GameObject titleScreen;

    // Use this for initialization
    void Start()
    {
        currentArea = "Title";
    }

    // Update is called once per frame
    void Update()
    {
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
                mainCam.GetComponent<Camera>().orthographicSize = 3.7f;
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[0];
                break;
            case "PizzaParlor":
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[1];
                break;
            case "Arcade":
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[2];
                break;
            case "Pool":
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[3];
                break;
            case "Home":
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[4];
                break;
            case "Win":
                GetComponent<GameManager>().bgmsrc.clip = GetComponent<GameManager>().bgm[6];
                break;
        }

    }
}
