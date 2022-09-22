using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UnitSelectionResponse : MonoBehaviour, ISelectResponse
{
    [Inject] UIManager uiManager;
    public void OnSelect(IUnit selection)
    { 
        selection?.ShowInfo();
    }
}
