using System;
using System.ComponentModel;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;

using DesktopMaid.ViewModels;
using Tmds.DBus.Protocol;

namespace DesktopMaid.Views;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    // Create timer for periodic function, using System.ComponentModel
    private readonly DispatcherTimer _timer;
    // Main Function
    public MainWindow()
    {
        InitializeComponent();
        // Makes Avalonia aware of transparency and therefore the background becomes transparent instead of black
        TransparencyLevelHint = new[] { WindowTransparencyLevel.Transparent };
        Background = Brushes.Transparent;
        DataContext = new MainWindowViewModel();
        // Gives a value to _timer, making it a new DispathcerTimer object
        _timer = new DispatcherTimer
        {
            // Parameters for DispatherTimer interval set to 200 milliseconds
            Interval = TimeSpan.FromMilliseconds(200)
        };
        // Starts timer and whenever smth occurs run Periodic function
        // Whenever tick is triggered, run a lambda with two parameters that naturally come with the Tick
        // command (sender, e), since we do not use it, we discard the data using _
        _timer.Tick += (_, _) => Periodic();
        // Start the timer
        _timer.Start();
    }
    // Run function when maid is clicked in any way, interprets it and runs appropriate function
    private void Window_PointerPress(object? sender, PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            // Checks if DataContent exists and if it does use vm as a placeholder for easy reference
            if (DataContext is MainWindowViewModel vm)
            {
                // Drags stuff and changes GIF source
                BeginMoveDrag(e);
                vm.ChangeGif("pickup1");
            }
        }
        if (e.GetCurrentPoint(this).Properties.IsRightButtonPressed)
        {
            this.Close();
        }
    }
    // Runs when the leftclick is released
    private void Window_PointerRelease(object? sender, PointerReleasedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.PointerUpdateKind == PointerUpdateKind.LeftButtonReleased)
        {
            // ~~~
            if (DataContext is MainWindowViewModel vm)
            {
                vm.ChangeGif("idle");
            }
        }
    }
    // Creates a random var, using System;
    Random rand = new Random();
    // Periodic function run everytime timer goes through
    private void Periodic()
    {
        if (DataContext is MainWindowViewModel vm)
        {
            // Determine random action and runs it
            int Temp = rand.Next(0, 5);
            if (Temp < 2) { vm.ChangeGif("idle"); }
            else if (Temp < 3) { vm.ChangeGif("walkNeg"); Position = new Avalonia.PixelPoint(Position.X + 1, Position.Y); }
            else { vm.ChangeGif("walkPos"); Position = new Avalonia.PixelPoint(Position.X - 1, Position.Y); }
        }
    }
}