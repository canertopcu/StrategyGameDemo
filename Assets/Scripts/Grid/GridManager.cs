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

    public void FinalizeBoxes(GridBox box, MenuItem building)
    {
        Vector3 totalPos = Vector3.zero;
        int count = (building.sizeX * building.sizeY);
        GridBox[] selectedBoxes = new GridBox[count];
        for (int i = box.x; i < box.x + building.sizeX; i++)
        {
            for (int j = box.y; j < box.y + building.sizeY; j++)
            {
                boxes[i, j].Fill(building);
                //selectedBoxes[i * building.sizeY + j] = boxes[i, j];
                totalPos += boxes[i, j].transform.position;
            }
        }

        totalPos = totalPos / (float)count;
        //totalPos.y = 1f;
        GameObject createdBuilding = Instantiate(building.WorldVisual, totalPos, Quaternion.identity, transform);

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
