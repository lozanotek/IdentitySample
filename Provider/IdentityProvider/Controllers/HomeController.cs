using System.Web.Mvc;

namespace IdentityProvider.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}