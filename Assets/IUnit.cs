public interface IUnit
{
    string unitName { get; set; }
    GridBox[] selectedBoxes { get; set; }
    void ShowInfo();
    void SettleDown();

}