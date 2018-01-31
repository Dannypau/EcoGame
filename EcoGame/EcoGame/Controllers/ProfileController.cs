using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcoGame.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {

            EcoGameModelContainer Db = new EcoGameModelContainer();


            return View(Db.ProfileSet);
        }
    }
}