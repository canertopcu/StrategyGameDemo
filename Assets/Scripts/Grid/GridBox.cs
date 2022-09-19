using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBox : MonoBehaviour
{
    public int id = -1;
    public int x, y;
    private bool isEmpty = true;  

    public void Fill()
    {
        isEmpty = false; 
    }

    public void SetEmpty()
    {
        isEmpty = true; 

    }

    public bool IsEmpty()
    {
        return isEmpty;
    }
 

}


