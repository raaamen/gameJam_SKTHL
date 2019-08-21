using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerInv : MonoBehaviour {

    public List<Trash> inventoryFull;

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}
    public void addRecycle()
    {
        Recycle recycling = new Recycle();
        if (inventoryFull.Count<1)
        {
            inventoryFull.Add(recycling);
        }
        else
        {
            player.GetComponent<scr_playerMovement>().invFull = true;
        }
    }
    public void depositAllTrash()
    {
        foreach (var item in inventoryFull)
        {
            GetComponent<GameManager>().totalTrash--;
        }
        inventoryFull.Clear();
    }


}
