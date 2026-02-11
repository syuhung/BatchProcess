using CommunityToolkit.Mvvm.ComponentModel;

namespace BatchProcess.ViewModels;

public class ViewModelBase : ObservableObject
{
    public string Test { get; set; } = "Process";
}