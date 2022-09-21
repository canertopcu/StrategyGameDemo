public interface IGridGenerator:IGridClear 
{
    GridBox[,] GenerateGrid();
    int GetRowCount();
    int GetColumnCount();

    void SetRowColumnCount(int row, int column); 



}