using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBox : MonoBehaviour
{
    public int id = -1;
    public int x, y;
    private bool isEmpty = true;
    private SpriteRenderer spriteRenderer;
    private MenuItem unit;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TempFill()
    {
        spriteRenderer.color = Color.blue;
        spriteRenderer.sortingOrder = 0;
    }

    public void TempCantFill()
    {
        spriteRenderer.color = Color.red;
        spriteRenderer.sortingOrder = 2;
    }


    public void Fill(MenuItem unit)
    {
        isEmpty = false;
        spriteRenderer.color = unit.color;
        this.unit = unit;
        spriteRenderer.sortingOrder = 0;
    }

    public void Fill()
    {
        isEmpty = false;
        spriteRenderer.color = unit.color;
        spriteRenderer.sortingOrder = 0;
    }

    public void SetEmpty()
    {
        isEmpty = true;
        spriteRenderer.color = Color.white;
        spriteRenderer.sortingOrder = 0;
    }

    public bool IsEmpty()
    {
        return isEmpty;
    }


}


