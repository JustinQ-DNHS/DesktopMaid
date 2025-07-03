using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using TodoList;

namespace DesktopMaid
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _filePath = "avares://DesktopMaid/Assets/idle.gif";

        public string FilePath
        {
            get => _filePath;
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    OnPropertyChanged(); // notify binding system
                }
            }
        }
        public new event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void ChangeImage()
        {
            FilePath = "avares://DesktopMaid/Assets/lowlow.gif";
        }
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
            this.PointerPressed += OnPointerPressed;
            this.PointerReleased += OnPointerReleased;
            DataContext = this;
        }
        private void OnPointerReleased(object? sender, PointerReleasedEventArgs e)
        {
            var point = e.GetCurrentPoint(this);
            if (point.Properties.PointerUpdateKind == PointerUpdateKind.LeftButtonReleased)
            {
                FilePath = "avares://DesktopMaid/assets/idle.gif";
            }
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
        // Inside your MainWindow class
        private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            {
                BeginMoveDrag(e);
                this.ChangeImage();
            }
        }
        private void OpenBranchWindow()
        {
            var branch = new BranchWindow();
            var testing = new TestingPage();
            branch.Show(); // or branch.ShowDialog(this) for modal
            testing.Show();
        }
    }
}