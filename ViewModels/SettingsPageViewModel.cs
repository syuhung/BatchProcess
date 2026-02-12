using BatchProcess.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace BatchProcess.ViewModels;

public partial class SettingsPageViewModel : PageViewModel
{
    [ObservableProperty]
    private List<string> _locationPaths;

    public SettingsPageViewModel()
    {
        PageName = ApplicationPageNames.Settings;

        // TEMP: Remove
        LocationPaths =
        [
            @"E:\Kingsoft\WPS Office",
            @"E:\BaiduNetdiskDownload",
            @"E:\Windows\assembly"
        ];
    }
}