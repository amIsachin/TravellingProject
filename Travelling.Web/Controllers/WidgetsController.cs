using System.Web.Mvc;
using Travelling.Service;
using Travelling.Web.ViewModels;

namespace Travelling.Web.Controllers
{
    public class WidgetsController : Controller
    {
        public ActionResult Widget()
        {
            PlaceWidgetViewModel model = new PlaceWidgetViewModel();
            model.Places = PlaceService.Instance.AllNewPlaces();
            return PartialView(model);
        }
    }
}