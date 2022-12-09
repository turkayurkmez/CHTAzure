using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace basicWebApp.Controllers
{
    public class BetaController : Controller
    {
        private readonly IFeatureManager featureManager;

        public BetaController(IFeatureManager featureManager)
        {
            this.featureManager = featureManager ?? throw new ArgumentNullException(nameof(featureManager));
        }
        [FeatureGate(MyFeatureFlags.Beta)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
