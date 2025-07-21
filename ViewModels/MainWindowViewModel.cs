using System;
using ReactiveUI;

namespace DesktopMaid.ViewModels;
// I'll be honest, not even I know how the setup works
public partial class MainWindowViewModel : ViewModelBase
{
    // Array of all filepaths, will matter in the future
    private string[] filePaths =
    {
        "chairpop.gif", "chatbox.png", "class.gif",
        "heart.png", "idle.gif", "low.gif", "lowlow.gif",
        "lowlowlow.gif", "scrub.gif", "walking_neg.gif", "walking_pos.gif", "watch.gif"
    };
    // Private string ref, stores actual data
    private string _gifPath = "avares://DesktopMaid/Assets/idle.gif";
    // Public string ref, data comes from here
    public string GifPath
    {
        get => _gifPath;
        set => this.RaiseAndSetIfChanged(ref _gifPath, $"avares://DesktopMaid/Assets/{value}");
    }
    // Sets animations when called, re-write later
    public void ChangeGif(string animation)
    {
        GifPath = animation switch
        {
            "idle" => filePaths[4],
            "pickup0" => filePaths[5],
            "pickup1" => filePaths[6],
            "pickup2" => filePaths[7],
            "walkNeg" => filePaths[9],
            "walkPos" => filePaths[10],
            _ => GifPath
        };
    }
}
