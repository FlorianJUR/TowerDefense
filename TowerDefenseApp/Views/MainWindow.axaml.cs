using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using TowerDefenseApp.ViewModels;
using Avalonia.Controls.Shapes; // to recognize Rectangle 

namespace TowerDefenseApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void OnTileTapped(object? sender, TappedEventArgs e)
    {
        Rectangle rectangle = (Rectangle)sender;
        TileViewModel tile = (TileViewModel)rectangle.DataContext;

        MainViewModel viewModel = (MainViewModel)DataContext;
        viewModel.SelectTile(tile);
    }

    private void OnBuildClicked(object? sender, RoutedEventArgs e)
    {
        MainViewModel viewModel = (MainViewModel)DataContext;
        viewModel.BuildTower();
    }
}