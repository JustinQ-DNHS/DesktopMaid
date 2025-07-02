using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using TodoList;

namespace DesktopMaid
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // ChatGPT
            TransparencyLevelHint = new[] { WindowTransparencyLevel.Transparent };
            Background = Brushes.Transparent;
            // End ChatGPT
            // Init TodoList
            Todo todoList = new Todo();
            // Handle right-click on the window
            this.PointerPressed += OnWindowRightClick;
            todoList.printList();
            todoList.addItem("New item", "desc", "4/2/23");
            todoList.printList();
            todoList.save();
            this.OpenBranchWindow();
        }

        private void OnWindowRightClick(object? sender, PointerPressedEventArgs e)
        {
            // Check if it's a right-click
            if (e.GetCurrentPoint(this).Properties.IsRightButtonPressed)
            {
                // For now, just show a message
                System.Console.WriteLine("Right-clicked the pet!");
                this.Close();
                // Later, you'll open your settings window here
            }
        }
        private void OpenBranchWindow()
        {
            var branch = new BranchWindow();
            branch.Show(); // or branch.ShowDialog(this) for modal
        }
    }
}