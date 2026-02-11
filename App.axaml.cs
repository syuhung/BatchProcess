using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BatchProcess.Data;
using BatchProcess.Factories;
using BatchProcess.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace BatchProcess;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();
        collection.AddSingleton<MainViewModel>();
        collection.AddTransient<HomePageViewModel>();
        collection.AddTransient<ProcessPageViewModel>();
        collection.AddTransient<ActionsPageViewModel>();
        collection.AddTransient<HistoryPageViewModel>();
        collection.AddTransient<MarcosPageViewModel>();
        collection.AddTransient<ReporterPageViewModel>();
        collection.AddTransient<SettingsPageViewModel>();
        
        collection.AddSingleton<Func<ApplicationPageNames, PageViewModel>>(serviceProvider => pageName => pageName switch
        {
            ApplicationPageNames.Home => serviceProvider.GetRequiredService<HomePageViewModel>(),
            ApplicationPageNames.Processes => serviceProvider.GetRequiredService<ProcessPageViewModel>(),
            ApplicationPageNames.Actions => serviceProvider.GetRequiredService<ActionsPageViewModel>(),
            ApplicationPageNames.History => serviceProvider.GetRequiredService<HistoryPageViewModel>(),
            ApplicationPageNames.Marcos => serviceProvider.GetRequiredService<MarcosPageViewModel>(),
            ApplicationPageNames.Reporter => serviceProvider.GetRequiredService<ReporterPageViewModel>(),
            ApplicationPageNames.Settings => serviceProvider.GetRequiredService<SettingsPageViewModel>(),
            _ => throw new ArgumentOutOfRangeException(nameof(pageName), pageName, null)
        });
        
        collection.AddSingleton<PageFactory>();
        
        var services = collection.BuildServiceProvider();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainView
            {
                DataContext = services.GetRequiredService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}