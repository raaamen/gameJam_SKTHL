using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerInv : MonoBehaviour {

    public List<Trash> inventoryFull;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addRecycle()
    {
        Recycle recycling = new Recycle();
        inventoryFull.Add(recycling);
    }
  

}
