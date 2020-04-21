using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample.Common.Settings;
using Sample.Common.Toolbox.Logger;
using Sample.Models;
using System.Diagnostics;

namespace Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly SampleSettings _sampleSettings;

        public HomeController(ILogger logger,
                              IOptions<SampleSettings> sampleSettings)
        {
            _logger = logger;
            _sampleSettings = sampleSettings.Value;
        }

        public IActionResult Index()
        {
            _logger.LogEvent("Page", "Home page loaded");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
