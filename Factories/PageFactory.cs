using System;
using BatchProcess.Data;
using BatchProcess.ViewModels;

namespace BatchProcess.Factories;

public class PageFactory(Func<ApplicationPageNames, PageViewModel> pageViewModelFactory)
{
    public PageViewModel GetPageViewModel(ApplicationPageNames pageName) => pageViewModelFactory.Invoke(pageName);
}