using Avalonia.Svg.Skia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BatchProcess.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _sideMenuExpanded = true;

    [RelayCommand]
    private void SideMenuResize()
    {
        /*SideMenuExpanded ^= true;*/
        SideMenuExpanded = !SideMenuExpanded;
    }
}