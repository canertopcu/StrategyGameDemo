
using UnityEngine;

public class RaycastBasedSelector : MonoBehaviour, ISelector
{
    private IUnit _selection;

    public void Check(Ray ray)
    {
        _selection = null;
        if (Physics.Raycast(ray, out var hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Building"))
            {
                _selection = selection.GetComponent<IUnit>();
            }

            if (selection.CompareTag("Soldier"))
            {
                _selection = selection.GetComponent<IUnit>();
            }
        }
    }

    public IUnit GetSelection()
    {
        return _selection;
    }
}
