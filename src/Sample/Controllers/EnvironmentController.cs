using Microsoft.AspNetCore.Mvc;
using Sample.Common.Toolbox;

namespace Sample.Controllers
{
    public class EnvironmentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["InstanceId"] = EnvironmentConfig.InstanceId;
            ViewData["IsStaging"] = EnvironmentConfig.IsStaging;
            ViewData["Settable"] = EnvironmentConfig.Settable;

            return View();
        }
        
        [HttpPost]
        public IActionResult Index(string value)
        {
            EnvironmentConfig.Settable = value;

            return RedirectToAction("Index");
        }
    }
}