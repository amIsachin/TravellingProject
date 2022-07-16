using System;
using System.IO;
using System.Web.Mvc;

namespace Travelling.Web.Controllers
{
    public class SharedController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /*------------------------------------ UploadImage START -----------------------------------------*/
        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var file = Request.Files[0];
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                file.SaveAs(path);
                result.Data = new { Success = true, ImageURL = string.Format("/Content/Images/{0}", fileName) };
            }
            catch (System.Exception ex)
            {
                result.Data = new { Success = false, Message = ex.Message };
            }
            //return Json(result, JsonRequestBehavior.AllowGet);
            return result;
        }
        /*------------------------------------ UploadImage START -----------------------------------------*/
    }
}