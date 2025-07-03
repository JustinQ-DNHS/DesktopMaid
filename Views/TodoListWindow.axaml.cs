using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;
using TodoList;

namespace DesktopMaid
{
    public partial class BranchWindow : Window
    {
        public BranchWindow()
        {
            InitializeComponent();
        }

        private void OnCloseClick(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}