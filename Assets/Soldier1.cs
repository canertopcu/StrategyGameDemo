using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier1 : MonoBehaviour, IUnit, IMove
{ 
    public GridBox[] selectedBoxes { get; set; }

    public string _unitName;
    public string unitName { get => _unitName; set => _unitName = value; }

    public void Move(GridBox targetBox)
    {
        throw new System.NotImplementedException();
    }

    public void SettleDown()
    {
        throw new System.NotImplementedException();
    }

    public void ShowInfo()
    {
        Debug.LogError(unitName);
    }


}
