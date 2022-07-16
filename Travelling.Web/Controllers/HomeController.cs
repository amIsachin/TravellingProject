using System.Web.Mvc;
using Travelling.Service;
using Travelling.Web.ViewModels;

namespace Travelling.Web.Controllers
{
    public class HomeController : Controller
    {
        /*------------------------------------ Index START ---------------------------------------*/
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.Places = PlaceService.Instance.AllPlaces();
            return View(model);
        }
        /*------------------------------------ Index END -----------------------------------------*/

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}