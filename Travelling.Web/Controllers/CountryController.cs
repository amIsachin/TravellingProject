using System.Web.Mvc;
using Travelling.Business;
using Travelling.Service;
using Travelling.Web.ViewModels;

namespace Travelling.Web.Controllers
{
    public class CountryController : Controller
    {
        //--> Create Object Data Context Class.
        //private CountryService countryService = new CountryService();

        /*---------------------------------------- Index START --------------------------------------------*/
        public ActionResult Index()
        {
            return View();
        }
        /*---------------------------------------- Index END ----------------------------------------------*/

        /*---------------------------------------- CountryTable START -------------------------------------*/
        public ActionResult CountryTable(string search, int? pageNo)
        {
            CountryViewModel model = new CountryViewModel();
            model.PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.SearchTerm = search;            
            model.AvailableCountry = CountryService.Instance.SearchCountry(model.SearchTerm, model.PageNo);   //--> pageNo = pageNo.HasValue ? pageNo : 1;
            model.LastPage = CountryService.Instance.LastPage();
            return PartialView(model);
        }
        /*---------------------------------------- CountryTable END ---------------------------------------*/

        /*---------------------------------------- Create START -------------------------------------------*/
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                CountryService.Instance.SaveCountry(country);
                ModelState.Clear();
                return RedirectToAction("CountryTable");
            }
            else
            {
                return new HttpStatusCodeResult(500);
            }
        }
        /*---------------------------------------- Create END ---------------------------------------------*/

        /*---------------------------------------- Edit START ---------------------------------------------*/
        [HttpGet]
        public ActionResult Edit(int? ID)
        {
            EditCountryViewModel model = new EditCountryViewModel();
            var country = CountryService.Instance.FindCountry(ID);
            model.ID = country.ID;
            model.Name = country.Name;
            model.Description = country.Description;
            model.ImageURL = country.ImageURL;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCountryViewModel model) //--> Country country
        {
            var existingCountry = new Country();
            existingCountry.ID = model.ID;
            existingCountry.Name = model.Name;
            existingCountry.Description = model.Description;
            existingCountry.ImageURL = model.ImageURL;

            CountryService.Instance.EditCountry(existingCountry);
            return RedirectToAction("CountryTable");
        }
        /*---------------------------------------- Edit END -----------------------------------------------*/

        /*---------------------------------------- Delete START -------------------------------------------*/
        [HttpPost]
        public ActionResult Delete(int? ID)
        {
            var country = CountryService.Instance.FindCountry(ID);
            CountryService.Instance.DeleteCountry(country);
            return RedirectToAction("CountryTable");
        }
        /*---------------------------------------- Delete END ---------------------------------------------*/
    }
}