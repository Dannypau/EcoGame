using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcoGame.Controllers
{
    public class EcosystemController : Controller
    {
        // GET: Ecosystem
        public ActionResult Index()
        {
            EcoGameModelContainer Db = new EcoGameModelContainer();
            return View(Db.EcosystemSet);
        }

        public ActionResult Edit(int? EcosystemId)
        {
            using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
            //using para usar en este contexto
            {
                
                var std = (from q in DBContext.EcosystemSet
                           where q.EcosystemId == EcosystemId
                           select q).FirstOrDefault();
                return View(std);
            }


        }
        [HttpPost]
        public ActionResult Edit(Ecosystem std)
        {




            if (ModelState.IsValid)
            {
                using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
                {
                    int currentAnimal = Convert.ToInt32(Request.Form["EcosystemId"]);//seleccion del combo

                    //consulta a la base

                    


                    var u = (from q in DBContext.EcosystemSet
                             where q.EcosystemId == std.EcosystemId
                             select q).FirstOrDefault();

                    if (u != null)
                    {
                        u.NameEcosystem = std.NameEcosystem;
                        u.ImgEcosystem = std.ImgEcosystem;
                        u.DescEcosystem = std.DescEcosystem;
                        u.RegEcosystem = std.RegEcosystem;
                        

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
        public ActionResult Create(Ecosystem objOrder)
        {
            EcoGameModelContainer db = new EcoGameModelContainer();
           

            db.EcosystemSet.Add(objOrder);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int EcosystemId)//consultar el estudainte q deseo borrar
        {
            using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
            //using para usar en este contexto
            {
                var std = (from q in DBContext.EcosystemSet
                           where q.EcosystemId == EcosystemId
                           select q).FirstOrDefault();
                return View(std);
            }
        }

        //POST
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(Ecosystem std)//consultar el estudainte q deseo borrar
        {
            using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
            //using para usar en este contexto
            {
                if (ModelState.IsValid)
                {
                    var u = (from q in DBContext.EcosystemSet
                             where q.EcosystemId == std.EcosystemId
                             select q).FirstOrDefault();

                    DBContext.EcosystemSet.Remove(u);

                    try
                    {
                        DBContext.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(" ", "El ecosistema tiene animales registrados");

                    }
                }
                return View();
            }
            

        }
    }
}