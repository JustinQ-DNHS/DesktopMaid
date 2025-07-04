using System;
using System.ComponentModel;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;

using DesktopMaid.ViewModels;
using Tmds.DBus.Protocol;

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
        if (e.GetCurrentPoint(this).Properties.IsRightButtonPressed)
        {
            this.Close();
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
    Random rand = new Random();
    private void Periodic()
    {
        if (DataContext is MainWindowViewModel vm)
        {
            // Determine random action
            int Temp = rand.Next(0, 5);
            if (Temp < 2) { vm.ChangeGif(); }
            else if (Temp < 3) { vm.ChangeGif(); }
            else { vm.ChangeGif(); }
        }
    }
}