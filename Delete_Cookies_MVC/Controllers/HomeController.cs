using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Delete_Cookies_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Create Cookie only once.
            if (TempData["Message"] == null && Request.Cookies["Name"] == null)
            {
                //Create a Cookie with a suitable Key.
                HttpCookie nameCookie = new HttpCookie("Name");

                //Set the Cookie value.
                nameCookie.Values["Name"] = "Mudassar Khan";

                //Set the Expiry date.
                nameCookie.Expires = DateTime.Now.AddDays(30);

                //Add the Cookie to Browser.
                Response.Cookies.Add(nameCookie);

                //Redirect in order to save Cookie in Browser.
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult DeleteCookie()
        {
            //Check if Cookie exists.
            if (Request.Cookies["Name"] != null)
            {
                //Fetch the Cookie using its Key.
                HttpCookie nameCookie = Request.Cookies["Name"];

                //Set the Expiry date to past date.
                nameCookie.Expires = DateTime.Now.AddDays(-1);

                //Update the Cookie in Browser.
                Response.Cookies.Add(nameCookie);

                //Set Message in TempData.
                TempData["Message"] = "Cookie deleted.";
            }
            else
            {
                //Set Message in TempData.
                TempData["Message"] = "Cookie not found.";
            }

            return RedirectToAction("Index");
        }
    }
}