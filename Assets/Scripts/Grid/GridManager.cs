using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(GridGenerator))]
public class GridManager : MonoBehaviour
{
    [Inject] private GameManager gameManager;

    private GridBox[,] boxes;

    public IGridGenerator gridGenerator;



    // Start is called before the first frame update
    void Start()
    {
        gameManager.gridManager = this;
        gridGenerator = GetComponent<IGridGenerator>();

        boxes = gridGenerator.GenerateGrid();
    }

    public bool CheckBoxes(GridBox box, MenuItem unit)
    {
        bool state = true;
        for (int i = box.x; i < box.x + unit.sizeX; i++)
        {
            for (int j = box.y; j < box.y + unit.sizeY; j++)
            {
                if (boxes[i, j].IsEmpty())
                {
                    boxes[i, j].TempFill();
                }
                else
                {
                    boxes[i, j].TempCantFill();
                    state = false;
                }
            }
        }
        return state;

    }

    public void FinalizeBoxes(GridBox box, MenuItem unit)
    {
        Vector3 totalPos = Vector3.zero;
        for (int i = box.x; i < box.x + unit.sizeX; i++)
        {
            for (int j = box.y; j < box.y + unit.sizeY; j++)
            {
                boxes[i, j].Fill(unit);
                totalPos += boxes[i, j].transform.position;
            }
        }

        totalPos = totalPos / ((float)unit.sizeX * (float)unit.sizeY);
        //totalPos.y = 1f;
        Instantiate(unit.WorldVisual,totalPos,Quaternion.identity,transform);
    }

    public void UncheckBoxes(GridBox box, MenuItem unit)
    {
        for (int i = box.x; i < box.x + unit.sizeX; i++)
        {
            for (int j = box.y; j < box.y + unit.sizeY; j++)
            {
                if (boxes[i, j].IsEmpty())
                {
                    boxes[i, j].SetEmpty();
                }
                else
                {
                    boxes[i, j].Fill();
                }
            }
        }

    }
}
