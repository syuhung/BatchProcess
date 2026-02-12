using Avalonia.Controls;
using Avalonia.Controls.Templates;
using BatchProcess.ViewModels;
using BatchProcess.Views;

namespace BatchProcess
{
    public class ViewLocator : IDataTemplate
    {
        public Control? Build(object? data)
        {
            if (data is null)
                return null;


            return data switch
            {
                HomePageViewModel => new HomePageView() { DataContext = data},
                ProcessPageViewModel => new ProcessPageView() { DataContext = data},
                ActionsPageViewModel => new ActionsPageView() { DataContext = data},
                HistoryPageViewModel => new HistoryPageView() { DataContext = data },
                MarcosPageViewModel => new MarcosPageView() { DataContext = data },
                ReporterPageViewModel => new ReporterPageView() { DataContext = data },
                SettingsPageViewModel => new SettingsPageView() { DataContext = data },
                _ => new TextBlock() { Text = $"未找到对应页面: {data.GetType().FullName}" }
            };
            
            //var viewName = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.InvariantCulture);
            //var viewType = Type.GetType(viewName);

            //if (viewType is null)
            //    return null;

            //var control = (Control)Activator.CreateInstance(viewType)!;
            //control.DataContext = data;
            //return control;
        }

        public bool Match(object? data) => data is ViewModelBase;
    }
}
