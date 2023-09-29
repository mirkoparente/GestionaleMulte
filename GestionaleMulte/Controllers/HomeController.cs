using GestionaleMulte.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionaleMulte.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin a)
        {
            List<Admin> list = Admin.AllAdmin();

            foreach (Admin p in list)
            {

                if (a.Username == p.Username && a.Password == p.Password)
                {
                    FormsAuthentication.SetAuthCookie(a.Username, true);
                    return RedirectToAction("ListaTrasgressori", "Trasgressori");
                }
            }
            return View();
        }
    }
}