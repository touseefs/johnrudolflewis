using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace aspZone.Samples.SimpleMvcFileUpload.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult Upload(HttpPostedFileBase file)
        {
            var fileName = Path.Combine(Request.MapPath("~/App_Data"), Path.GetFileName(file.FileName));
            file.SaveAs(fileName);
            return RedirectToAction("Index");
        }
    }
}
