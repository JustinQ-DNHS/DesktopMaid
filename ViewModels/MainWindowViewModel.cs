using ReactiveUI;

namespace DesktopMaid.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private string _gifPath = "avares://DesktopMaid/Assets/idle.gif";
    public string GifPath
    {
        get => _gifPath;
        set => this.RaiseAndSetIfChanged(ref _gifPath, value);
    }
    public void ChangeGif()
    {
        GifPath = GifPath == "avares://DesktopMaid/Assets/idle.gif" 
            ? "avares://DesktopMaid/Assets/lowlow.gif" 
            : "avares://DesktopMaid/Assets/idle.gif";
    }
}
