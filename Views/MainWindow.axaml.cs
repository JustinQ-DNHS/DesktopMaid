using System.ComponentModel;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;

using DesktopMaid.ViewModels;

namespace DesktopMaid.Views;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    public MainWindow()
    {
        InitializeComponent();
        // Makes Avalonia aware of transparency and therefore the background becomes transparent instead of black
        TransparencyLevelHint = new[] { WindowTransparencyLevel.Transparent };
        Background = Brushes.Transparent;
        DataContext = new MainWindowViewModel();
    }
    private void Window_PointerPress(object? sender, PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                BeginMoveDrag(e);
                vm.ChangeGif();
            }
        }
    }
    private void Window_PointerRelease(object? sender, PointerReleasedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.PointerUpdateKind == PointerUpdateKind.LeftButtonReleased)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                vm.ChangeGif();
            }
        }
    } 
}