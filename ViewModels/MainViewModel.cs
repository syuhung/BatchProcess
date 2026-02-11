using Avalonia.Svg.Skia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BatchProcess.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private const string BUTTON_ACTIVE_CLASS = "active";

    [ObservableProperty]
    private bool _sideMenuExpanded = true;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
    [NotifyPropertyChangedFor(nameof(ProcessPageIsActive))]
    private ViewModelBase _currentPage;

    public bool HomePageIsActive => CurrentPage == _homePage;
    public bool ProcessPageIsActive => CurrentPage == _processPage;

    private readonly HomePageViewModel _homePage = new();
    private readonly ProcessPageViewModel _processPage = new();

    public MainViewModel()
    {
        CurrentPage = _processPage;
    }

    [RelayCommand]
    private void SideMenuResize()
    {
        /*SideMenuExpanded ^= true;*/
        SideMenuExpanded = !SideMenuExpanded;
    }

    [RelayCommand]
    private void NavigateToHome()
    {
        CurrentPage = _homePage;
    }

    [RelayCommand]
    private void NavigateToProcess()
    {
        CurrentPage = _processPage;
    }
}