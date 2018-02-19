using EcoGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EcoGame.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User std)
        {

            EcoGameModelContainer DBContext = new EcoGameModelContainer();
            
                var currentAnimal = Request.Form["UserName"];
                var objCustomer = (from q in DBContext.UserSet
                                   where q.NameUser ==std.NameUser
                                   select q).FirstOrDefault();
            if (ModelState.IsValid)
            {
                try
                {

                    if (objCustomer.Perfil.ProfileId == 2)
                    {
                        return RedirectToAction("Admin", "Login");
                    }
                    else
                    {

                        return RedirectToAction("Index", "Home");

                    }
                }catch (Exception ex)
                {
                    ModelState.AddModelError("", "Usuario no registrado");
                }

            }
           
            return View();
            




  

            
  
           
           
        }

    }
}