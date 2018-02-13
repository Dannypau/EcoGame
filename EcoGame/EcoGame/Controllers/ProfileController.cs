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
        public ActionResult Edit(int? ProfileId)
        {
            using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
            //using para usar en este contexto
            {

                var std = (from q in DBContext.ProfileSet
                           where q.ProfileId == ProfileId
                           select q).FirstOrDefault();
                return View(std);
            }


        }
        [HttpPost]
        public ActionResult Edit(Profile std)
        {




            if (ModelState.IsValid)
            {
                using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
                {
                    int currentUser = Convert.ToInt32(Request.Form["ProfileId"]);//seleccion del combo

                    //consulta a la base




                    var u = (from q in DBContext.ProfileSet
                         
                             where q.ProfileId == std.ProfileId
                             select q).FirstOrDefault();

                    if (u != null)
                    {
                        u.NameProfile = std.NameProfile;
                    


                    }

                    DBContext.SaveChanges();


                }


                return RedirectToAction("Index");

            }




            return View(std);

        }


        public ActionResult Create()
        {

            return View();
        }



        [HttpPost]
        public ActionResult Create(Profile objOrder)
        {
            EcoGameModelContainer db = new EcoGameModelContainer();


            db.ProfileSet.Add(objOrder);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int ProfileId)//consultar el estudainte q deseo borrar
        {
            using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
            //using para usar en este contexto
            {
                var std = (from q in DBContext.ProfileSet
                           where q.ProfileId == ProfileId
                           select q).FirstOrDefault();
                return View(std);
            }
        }

        //POST
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(Profile std)//consultar el estudainte q deseo borrar
        {
            using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
            //using para usar en este contexto
            {
                var u = (from q in DBContext.ProfileSet
                         where q.ProfileId == std.ProfileId
                         select q).FirstOrDefault();

                DBContext.ProfileSet.Remove(u);
                DBContext.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}