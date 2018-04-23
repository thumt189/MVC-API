using Basic.code;
using Basic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Basic.Controllers.StoreProceduce
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(account account)
        {
            var result = new AccountModel().Login(account.username, account.password);
            if (result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { username = account.username, name = account.name });
                //Session["name"] = account.name.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên tài khoản hoặc mật khẩu không đúng");
            }
            return View(account);
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Login");
        }
	}
}