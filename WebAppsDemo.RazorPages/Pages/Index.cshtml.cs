using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppsDemo.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string Header { get; set; }

        public void OnGet()
        {
            if (DateTime.Now.Hour < 12)
            {
                Header = "Dobré dopo";
            }
            else
            {
                Header = "Zdravím zdravím";
            }
        }
    }
}
