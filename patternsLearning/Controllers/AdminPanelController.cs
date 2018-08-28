using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace patternsLearning.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        public ActionResult Index()
        {
            return View();
        }

        //ну тут крч всякая дичь пошла
        [Authorize]
        public RedirectToRouteResult AddSection() {
            return  RedirectToAction("Index","AdminPanel");
        }
    }
}