using BatchProcess.Data;

namespace BatchProcess.ViewModels
{
    internal class ProcessPageViewModel : PageViewModel
    {
        public string Text { get; set; } = "This is Process Page";

        public ProcessPageViewModel()
        {
            PageName = ApplicationPageNames.Processes;
        }
    }
}