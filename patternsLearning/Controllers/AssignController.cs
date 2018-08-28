using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using patternsLearning.Models;
using System.Web.Security;

namespace patternsLearning.Controllers
{
    public class AssignController : Controller
    {
        // GET: Assign
        public ActionResult Login()
        {
            return View();
        }

        // POST: Assign
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid) {
                User user = null;
                using (UserEntities db = new UserEntities()) {
                    user = db.User.FirstOrDefault(u => u.Login == model.Login && u.Password==model.Password);
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Index","AdminPanel");
                }
                else {
                    ModelState.AddModelError("", "Ошибка авторизации! Пользователя с такими логином и паролем не существует");
                }
            }
            return View();
        }
    }
}