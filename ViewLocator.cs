using Avalonia.Controls;
using Avalonia.Controls.Templates;
using BatchProcess.ViewModels;
using BatchProcess.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace BatchProcess
{
    internal class ViewLocator : IDataTemplate
    {
        public Control? Build(object? data)
        {
            if (data is null)
                return null;
            
            var viewName = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.InvariantCulture);
            var viewType = Type.GetType(viewName);

            if (viewType is null)
                return null;

            var control = (Control)Activator.CreateInstance(viewType)!;
            control.DataContext = data;
            return control;
        }

        public bool Match(object? data) => data is ViewModelBase;
    }
}
