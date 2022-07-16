using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Travelling.Business;
using Travelling.Service;
using Travelling.Web.ViewModels;

namespace Travelling.Web.Controllers
{
    public class PlaceController : Controller
    {
        //--> Create object Data context Class.
        //PlaceService placeService = new PlaceService();
        //CityService cityService = new CityService();

        /*--------------------------------------- Index START -------------------------------------------*/
        public ActionResult Index()
        {
            return View();
        }
        /*--------------------------------------- Index END ---------------------------------------------*/

        /*--------------------------------------- Listing START -----------------------------------------*/
        public ActionResult Listing(string search)
        {
            return PartialView(PlaceService.Instance.SearchPlace(search).ToList());
        }
        /*--------------------------------------- Listing END -------------------------------------------*/

        /*--------------------------------------- Action START ------------------------------------------*/
        [HttpGet]
        public ActionResult Action(int? ID)
        {
            CityPlaceViewModels model = new CityPlaceViewModels();
            var record = new Place();
            if (ID.HasValue)
            {
                record = PlaceService.Instance.FindPlace(ID.Value);
            }
            model.City = CityService.Instance.AllCity();
            model.ID = record.ID;
            model.Name = record.Name;
            model.Description = record.Description;
            model.Price = record.Price;
            model.ImageURL = record.ImageURL;

            return PartialView(model);
        }

        [HttpPost]
        public JsonResult Action(PlaceViewModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            var existingPlace = new Place();
            if (model.ID > 0)
            {
                //var existingProduct = ProductsService.Instance.GetProduct(model.ID);
                //existingPlace = placeService.FindPlace(model.ID);

                existingPlace.ID = model.ID;
                existingPlace.Name = model.Name;
                existingPlace.Description = model.Description;
                existingPlace.Price = model.Price;
                existingPlace.ImageURL = model.ImageURL;

                //--> Place has changes. Therfore we assigning null.
                existingPlace.City = null;

                existingPlace.City = CityService.Instance.FindCity(model.cityID);
                result = PlaceService.Instance.UpdatePlace(existingPlace);
            }
            else
            {
                existingPlace.ID = model.ID;
                existingPlace.Name = model.Name;
                existingPlace.Description = model.Description;
                existingPlace.Price = model.Price;
                existingPlace.ImageURL = model.ImageURL;
                existingPlace.City = CityService.Instance.FindCity(model.cityID);
                result = PlaceService.Instance.SavePlace(existingPlace);
            }

            //--> Here is JsonResult Logic.
            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Opps something went wrong" };
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        /*--------------------------------------- Action END --------------------------------------------*/

        /*--------------------------------------- Delete START ------------------------------------------*/
        [HttpPost]
        public ActionResult Delete(int? ID)
        {
            var record = PlaceService.Instance.FindPlace(ID);
            PlaceService.Instance.DeletePlace(record);
            return RedirectToAction("Listing");
        }
        /*--------------------------------------- Delete END --------------------------------------------*/
    }
}