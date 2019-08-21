using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startButton : MonoBehaviour {

    public GameObject manager;
    public GameObject titleScreen;

	// Use this for initialization
    public void start()
    {
        titleScreen.SetActive(false);
        manager.GetComponent<scr_camManage>().currentArea = "Home";
    }

}
