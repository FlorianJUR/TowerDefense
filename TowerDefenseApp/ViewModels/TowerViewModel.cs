using TowerDefenseApp.GameLogic.Towers;

namespace TowerDefenseApp.ViewModels;

public class TowerViewModel
{
    // for the tower
    public double posX { get; set; }
    public double posY { get; set; }
    public double width { get; set; }
    public double height { get; set; }
    public string color { get; set; } = "purple";

    // for the range
    public double rangeX { get; set; }
    public double rangeY { get; set; }
    public double rangeSize { get; set;}    //diameter needed for the view

    public TowerViewModel(Tower tower)
    {
        // for the tower dimentions
        int towerSize = 28;
        int offset = (TileViewModel.size - towerSize) / 2;

        posX = tower.Column * TileViewModel.size + offset;
        posY = tower.Row * TileViewModel.size + offset;
        width = towerSize;
        height = towerSize;

        // for the range dimentions
        double centerX = tower.Column * TileViewModel.size + TileViewModel.size / 2.0;
        double centerY = tower.Row * TileViewModel.size + TileViewModel.size / 2.0;

        rangeSize = tower.Range * 2 * TileViewModel.size;

        rangeX = centerX - rangeSize/2;
        rangeY = centerY - rangeSize/2;

    }
}