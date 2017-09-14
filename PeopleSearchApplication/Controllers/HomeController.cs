using System.Web.Mvc;

namespace PeopleSearchApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}