using System;
using System.Web.Mvc;
using Travelling.Business;
using Travelling.Service;
using Travelling.Web.ViewModels;

namespace Travelling.Web.Controllers
{
    public class CityController : Controller
    {
        //--> Create object Data context class.
        //CityService cityService = new CityService();
        //CountryService countryService = new CountryService();

        /*--------------------------------------- Index START -------------------------------------------*/
        public ActionResult Index()
        {
            return View();
        }
        /*--------------------------------------- Index END ---------------------------------------------*/

        /*--------------------------------------- CityTable START ---------------------------------------*/
        public ActionResult CityTable(string search, int? pageNo)
        {
            CitySearchViewModel model = new CitySearchViewModel();
            model.SearchTerm = search;
            var totalRecord = CityService.Instance.TotalCityCount(model.SearchTerm);
            model.PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            model.City = CityService.Instance.SearchCity(search, model.PageNo);
            if (model.City != null)
            {
                model.Pager = new Pager(totalRecord, model.PageNo, 5);
                return PartialView(model);
            }
            else
            {
                return HttpNotFound();
            }
        }
        /*--------------------------------------- CityTable END -----------------------------------------*/

        /*--------------------------------------- Create START ------------------------------------------*/
        [HttpGet]
        public ActionResult Action(int? ID)
        {
            var record = new City();
            CityViewModel model = new CityViewModel();
            if (ID.HasValue)
            {
                record = CityService.Instance.FindCity(ID.Value);
            }

            //--> model.countryID = record.Country.ID;
            model.ID = record.ID;
            model.Name = record.Name;
            model.Description = record.Description;
            model.ImageURL = record.ImageURL;
            //model.DropDownID = record.Country.ID >= 0 ? record.Country.ID : Convert.ToInt32(string.Empty);
            model.Country = CountryService.Instance.AllCountry();

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(CityCountryViewModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            var existingCity = new City();
            if (model.ID > 0)  //--> city.ID > 0 
            {
                //result = cityService.UpdateCity(city);
                existingCity.ID = model.ID;
                existingCity.Name = model.Name;
                existingCity.Description = model.Description;
                existingCity.ImageURL = model.ImageURL;

                existingCity.Country = CountryService.Instance.FindCountry(model.countryID);
                result = CityService.Instance.UpdateCity(existingCity);
            }
            else
            {
                existingCity.ID = model.ID;
                existingCity.Name = model.Name;
                existingCity.Description = model.Description;
                existingCity.ImageURL = model.ImageURL;
                existingCity.Country = CountryService.Instance.FindCountry(model.countryID);

                result = CityService.Instance.SaveCity(existingCity);
            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Opps Somenthing went wrong" };
            }

            return Json(json, JsonRequestBehavior.AllowGet);

        }
        /*--------------------------------------- Create END --------------------------------------------*/

        /*--------------------------------------- Delete START ------------------------------------------*/
        [HttpGet]
        public ActionResult Delete(int? ID)
        {
            var record = CityService.Instance.FindCity(ID);
            return PartialView("_Delete", record);
        }

        [HttpPost]
        public JsonResult Delete(City city)
        {
            JsonResult json = new JsonResult();
            var result = false;
            result = CityService.Instance.DeleteCity(city);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Opps Somenthing went wrong" };
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        /*--------------------------------------- Delete END --------------------------------------------*/
    }
}