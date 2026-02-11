using BatchProcess.Data;

namespace BatchProcess.ViewModels
{
    public class HomePageViewModel : PageViewModel
    {
        public string Text { get; set; } = "This is Home Page";

        public HomePageViewModel()
        {
            PageName = ApplicationPageNames.Home;
        }
    }
}