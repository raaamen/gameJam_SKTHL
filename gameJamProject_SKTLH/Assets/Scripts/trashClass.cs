using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public bool recycling;

    public Trash(bool canRecycle)
    {
        if (canRecycle)
        {
            recycling = true;
        }
        else recycling = false;
    }
}
public class Recycle : Trash
{
    public Recycle() : base(true)
    {

    }
}

