using Avalonia.Controls;
using Avalonia.Input;
using TodoList;

namespace DesktopMaid
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Handle right-click on the window
            this.PointerPressed += OnWindowRightClick;
        }
        
        private void OnWindowRightClick(object? sender, PointerPressedEventArgs e)
        {
            // Check if it's a right-click
            if (e.GetCurrentPoint(this).Properties.IsRightButtonPressed)
            {
                // For now, just show a message
                System.Console.WriteLine("Right-clicked the pet!");
                
                // Later, you'll open your settings window here
            }
        }
    }
}