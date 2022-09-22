using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PowerPlant : MonoBehaviour, IBuilding
{
    [Inject] UIManager uiManager;
    public GridBox[] selectedBoxes { get; set; }

    public List<IUnit> units;

    public string _unitName;
    public string unitName { get => _unitName; set => _unitName = value; }

    public void Demolish()
    {
        throw new System.NotImplementedException();
    }

    public void SettleDown()
    {
        throw new System.NotImplementedException();
    }

    public void ShowInfo()
    {
        
        Debug.LogError(unitName) ;

    }

}
