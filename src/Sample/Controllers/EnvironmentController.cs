using Microsoft.AspNetCore.Mvc;
using Sample.Common.Toolbox;
using System.Threading.Tasks;

namespace Sample.Controllers
{
    public class EnvironmentController : Controller
    {
        private readonly IKeyVault _vault;
        public string Message { get; set; }

        public EnvironmentController(IKeyVault vault)
        {
            _vault = vault;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["SecretValue"] = await _vault.GetSecret("SampleAppSecret");
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