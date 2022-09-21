using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour, IGridGenerator
{
    private GridBox[,] boxes;
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] public int rowCount = 5;
    [SerializeField] public int columnCount = 5;
    public float boxSize = 1;
    public float paddingSpace = 0.1f;

    public void ClearAllBoxes()
    {
        foreach (var item in GetComponentsInChildren<GridBox>())
        {
            DestroyImmediate(item.gameObject); //TODO:pool this after
        }
        boxes = null;
    }

    [ContextMenu("Generate Grid")]
    public GridBox[,] GenerateGrid()
    {
        ClearAllBoxes();
        boxes = new GridBox[columnCount, rowCount];
        float totalSizeX = (columnCount * (boxSize) + (columnCount - 1) * paddingSpace);
        float totalSizeY = (rowCount * (boxSize) + (rowCount - 1) * paddingSpace);
        float unitSizeX = totalSizeX / columnCount;
        float unitSizeY = totalSizeY / rowCount;

        for (int y = 0; y < rowCount; y++)
        {
            for (int x = 0; x < columnCount; x++)
            {
#if UNITY_EDITOR
                GameObject box = UnityEditor.PrefabUtility.InstantiatePrefab(boxPrefab, transform) as GameObject;
#else

                GameObject box = Instantiate(boxPrefab, transform);
#endif
                box.name = "GridBox(" + x + "," + y + ")";
                GridBox b = box.GetComponent<GridBox>();
                b.x = x;
                b.y = y;
                boxes[x, y] = b;

                //* distance - ((distance * (columnCount - 1)) / 2f)
                //* distance - ((distance * (rowCount - 1)) / 2f)
                box.transform.localPosition = new Vector2(x * unitSizeX - ((totalSizeX - unitSizeX) / 2), y * unitSizeY - ((totalSizeY - unitSizeY) / 2));
                b.id = x + y * rowCount;

                box.transform.localScale = Vector3.one * boxSize;
            }
        }
        return boxes;

    }

    public int GetRowCount()
    {
        return rowCount;
    }

    public int GetColumnCount()
    {
        return columnCount;
    }




    public void ResetAllGridBoxes()
    {
        for (int y = 0; y < rowCount; y++)
        {
            for (int x = 0; x < columnCount; x++)
            {
                boxes[x, y].SetEmpty();
            }
        }
    }

    public void ResetMatchedGridBoxes(List<GridBox> gridBoxes)
    {
        foreach (var item in gridBoxes)
        {
            item.SetEmpty();
        }
    }


    public void SetRowColumnCount(int row, int column)
    {
        rowCount = row;
        columnCount = column;

    }
}
