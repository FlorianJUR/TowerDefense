using TowerDefenseApp.GameLogic.Towers;

namespace TowerDefenseApp.ViewModels;

public class TowerViewModel
{
    public double posX { get; set; }
    public double posY { get; set; }
    public double width { get; set; }
    public double height { get; set; }
    public string color { get; set; } = "purple";

    public TowerViewModel(Tower tower)
    {
        int towerSize = 28;
        int offset = (TileViewModel.size - towerSize) / 2;

        posX = tower.Column * TileViewModel.size + offset;
        posY = tower.Row * TileViewModel.size + offset;
        width = towerSize;
        height = towerSize;
    }
}