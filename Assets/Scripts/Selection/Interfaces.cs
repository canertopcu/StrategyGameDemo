
using UnityEngine;

public interface ISelector
{
    IUnit GetSelection();
    void Check(Ray ray);
}
public interface ISelectResponse
{
    void OnSelect( IUnit selection);
}
public interface IRaycastProvider
{
    Ray CreateRay();
}
