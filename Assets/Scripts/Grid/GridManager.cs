using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class GridManager : MonoBehaviour
{
    public IGridGenerator gridGenerator; 

    // Start is called before the first frame update
    void Awake()
    {
        gridGenerator = GetComponent<IGridGenerator>(); 
    }

    private void Start()
    {
        gridGenerator.GenerateGrid();
    }
   
     
}
