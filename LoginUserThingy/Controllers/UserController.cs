using System.Web.Mvc;
using UsersLibrary;

namespace LoginUserThingy.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index(){return View();}
        public ActionResult Logud()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index"); // Ikke logget ind? Tilbage til Index.
            }
            Session["Username"] = null;
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["Username"] != null)
            {
                return RedirectToAction("Index"); // Allerede logget ind? Så ryger man til Index.
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users u)
        {
            if (ModelState.IsValid)
            {
                UserLibrary users = new UserLibrary();
                foreach (var user in users.Users)
                {
                    if (user.Username == u.Username && user.Passwd == u.Passwd)
                    {
                        Session["Username"] = user.Username;
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
    }
}
