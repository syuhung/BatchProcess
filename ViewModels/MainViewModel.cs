using Avalonia.Svg.Skia;
using BatchProcess.Data;
using BatchProcess.Factories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BatchProcess.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly PageFactory _pageFactory;

    [ObservableProperty]
    private bool _sideMenuExpanded = true;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
    [NotifyPropertyChangedFor(nameof(ProcessPageIsActive))]
    [NotifyPropertyChangedFor(nameof(ActionsPageIsActive))]
    [NotifyPropertyChangedFor(nameof(HistoryPageIsActive))]
    [NotifyPropertyChangedFor(nameof(MarcosPageIsActive))]
    [NotifyPropertyChangedFor(nameof(ReporterPageIsActive))]
    [NotifyPropertyChangedFor(nameof(SettingsPageIsActive))]
    private PageViewModel _currentPage;

    public bool HomePageIsActive => CurrentPage.PageName == ApplicationPageNames.Home;
    public bool ProcessPageIsActive => CurrentPage.PageName == ApplicationPageNames.Processes;
    public bool ActionsPageIsActive => CurrentPage.PageName == ApplicationPageNames.Actions;
    public bool HistoryPageIsActive => CurrentPage.PageName == ApplicationPageNames.History;
    public bool MarcosPageIsActive => CurrentPage.PageName == ApplicationPageNames.Marcos;
    public bool ReporterPageIsActive => CurrentPage.PageName == ApplicationPageNames.Reporter;
    public bool SettingsPageIsActive => CurrentPage.PageName == ApplicationPageNames.Settings;

    /// <summary>
    /// Design-time only constructor
    /// </summary>
    public MainViewModel()
    {
        
        CurrentPage = new SettingsPageViewModel();
    }

    public MainViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory;

        CurrentPage = pageFactory.GetPageViewModel(ApplicationPageNames.Home);
    }

    [RelayCommand]
    private void SideMenuResize()
    {
        /*SideMenuExpanded ^= true;*/
        SideMenuExpanded = !SideMenuExpanded;
    }

    [RelayCommand]
    private void NavigateToHome() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Home);

    [RelayCommand]
    private void NavigateToProcess() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Processes);

    [RelayCommand]
    private void NavigateToActions() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Actions);

    [RelayCommand]
    private void NavigateToHistory() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.History);

    [RelayCommand]
    private void NavigateToMarcos() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Marcos);

    [RelayCommand]
    private void NavigateToReporter() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Reporter);

    [RelayCommand]
    private void NavigateToSettings() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Settings);
}