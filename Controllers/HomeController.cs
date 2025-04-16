using System.Diagnostics;
using HellenicBankAssociation.Models;
using Microsoft.AspNetCore.Mvc;

namespace HellenicBankAssociation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        List<string> GreekBanks = new List<string>
        {
            "National Bank of Greece",
            "Piraeus Bank",
            "Alpha Bank",
            "Eurobank",
            "Attica Bank",
            "Optima Bank",
            "Vivabank",
            "Citibank Europe",
            "Aegean Baltic Bank"
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetBanks([FromQuery] string name = null)
        {
            List<string> banks = GreekBanks;

            if (!string.IsNullOrEmpty(name))
                banks = banks.Where(b => b.StartsWith(name, StringComparison.CurrentCultureIgnoreCase)).ToList();

            return Ok(banks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
