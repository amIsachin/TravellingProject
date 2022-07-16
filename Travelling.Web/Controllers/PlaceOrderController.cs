using System.Web.Mvc;
using Travelling.Business;
using Travelling.Service;
using Travelling.Web.ViewModels;

namespace Travelling.Web.Controllers
{
    public class PlaceOrderController : Controller
    {
        /*--------------------------------------- ShowOrderPage START ---------------------------------------*/
        [HttpGet]
        public ActionResult ShowOrderPage(int? ID)
        {
            ShowOrderPage model = new ShowOrderPage();
            var record = PlaceService.Instance.FindPlace(ID);
            model.ID = record.ID;
            model.Name = record.Name;
            model.Description = record.Description;
            model.ImageURL = record.ImageURL;
            model.Price = record.Price;
            return View(model);
        }
        /*--------------------------------------- ShowOrderPage END -----------------------------------------*/

        /*--------------------------------------- ConfirmBooking START --------------------------------------*/
        [HttpPost]
        public JsonResult ConfirmBooking(int ID, string firstName, string lastName, string userName, string userEmail)
        {
            JsonResult json = new JsonResult();
            var saveUserOrderDetails = new PlaceOrder();

            var record = PlaceService.Instance.FindPlace(ID);

            saveUserOrderDetails.DestinationPlaceID = record.ID;
            saveUserOrderDetails.DestinationName = record.Name;
            saveUserOrderDetails.DestinationDescription = record.Description;
            saveUserOrderDetails.DestinationImageURL = record.ImageURL;
            saveUserOrderDetails.DestinationPrice = record.Price;
            saveUserOrderDetails.City = record.City;

            saveUserOrderDetails.FirstName = firstName;
            saveUserOrderDetails.LastName = lastName;
            saveUserOrderDetails.UserName = userName;
            saveUserOrderDetails.Email = userEmail;

            var result = PlaceOrderService.Instance.SaveOrder(saveUserOrderDetails);

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
        /*--------------------------------------- ConfirmBooking END ----------------------------------------*/
    }
}