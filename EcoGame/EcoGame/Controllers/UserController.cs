using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcoGame.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            EcoGameModelContainer Db = new EcoGameModelContainer();

            return View(Db.UserSet);
        }
        public ActionResult Edit(int? UserId)
        {
            using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
            //using para usar en este contexto
            {
                PopulateCustomers();
                var std = (from q in DBContext.UserSet
                           where q.UserId == UserId
                           select q).FirstOrDefault();
                return View(std);
            }


        }
        [HttpPost]
        public ActionResult Edit(User std)
        {
            if (ModelState.IsValid)
            {
                using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
                {
                    int currentUser = Convert.ToInt32(Request.Form["ProfileId"]);//seleccion del combo

                    //consulta a la base

                    var objCustomer = (from q in DBContext.ProfileSet
                                       where q.ProfileId == currentUser
                                       select q).FirstOrDefault();


                    var u = (from q in DBContext.UserSet
                             where q.UserId == std.UserId
                             select q).FirstOrDefault();

                    if (u != null)
                    {
                        u.NameUser = std.NameUser;
                        u.PswUser = std.PswUser;
                      
                        u.Perfil = objCustomer;

                    }

                    DBContext.SaveChanges();


                }


                return RedirectToAction("Index");

            }




            return View(std);

        }



        public ActionResult Create()
        {
            PopulateCustomers();
            return View();
        }

        private void PopulateCustomers(object selectedUser = null)
        {
            EcoGameModelContainer db = new EcoGameModelContainer();
            var customersQuery = from d in db.ProfileSet
                                 orderby d.NameProfile
                                 select d;

            ViewBag.ProfileID = new SelectList(customersQuery, "ProfileId", "NameProfile", selectedUser);


        }

        [HttpPost]
        public ActionResult Create(User objOrder)
        {
            EcoGameModelContainer db = new EcoGameModelContainer();
            int currentUser = Convert.ToInt32(Request.Form["ProfileId"]);//seleccion del combo

            //consulta a la base

            var objCustomer = (from q in db.ProfileSet
                               where q.ProfileId == currentUser
                               select q).FirstOrDefault();

            objOrder.Perfil = objCustomer;
            db.UserSet.Add(objOrder);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int UserId)//consultar el estudainte q deseo borrar
        {
            using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
            //using para usar en este contexto
            {
                var std = (from q in DBContext.UserSet
                           where q.UserId == UserId
                           select q).FirstOrDefault();
                return View(std);
            }
        }

        //POST
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(User std)//consultar el estudainte q deseo borrar
        {
            using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
            //using para usar en este contexto
            {
                var u = (from q in DBContext.UserSet
                         where q.UserId == std.UserId
                         select q).FirstOrDefault();

                DBContext.UserSet.Remove(u);
                DBContext.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}