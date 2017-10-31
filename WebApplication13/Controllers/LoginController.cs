using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace WebApplication13.Controllers
{
    public class LoginController : Controller
    {
        shazyEntities sb = new shazyEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Account ab)
        {
            var obj = sb.Accounts.Where(x=> x.Email==ab.Email && x.Password==ab.Password).SingleOrDefault();
            if (obj!=null)
            {
                FormsAuthentication.SetAuthCookie(ab.Email,false);
                return RedirectToAction("Index","Home");
            }
            return View();
        
        }
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        
        }
    }
}