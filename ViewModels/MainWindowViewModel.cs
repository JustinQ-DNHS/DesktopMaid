using System;
using ReactiveUI;

namespace DesktopMaid.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private string[] filePaths = { "avares://DesktopMaid/Assets/idle.gif" };
    private string _gifPath = "avares://DesktopMaid/Assets/idle.gif";
    public string GifPath
    {
        get => _gifPath;
        set => this.RaiseAndSetIfChanged(ref _gifPath, $"avares://DesktopMaid/Assets/{value}");
    }
    public void ChangeGif()
    {
        GifPath = GifPath == "avares://DesktopMaid/Assets/idle.gif" 
            ? "lowlow.gif" 
            : "idle.gif";
    }
}
