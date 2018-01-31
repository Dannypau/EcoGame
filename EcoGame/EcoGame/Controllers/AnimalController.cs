using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcoGame.Models;


namespace EcoGame.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        public ActionResult Index()
        {
            EcoGameModelContainer Db = new EcoGameModelContainer();

            return View(Db.AnimalSet);
        }
        public ActionResult Edit(int? AnimalId)
        {
            using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
            //using para usar en este contexto
            {
                PopulateCustomers();
                var std = (from q in DBContext.AnimalSet
                           where q.AnimalId == AnimalId
                           select q).FirstOrDefault();
                return View(std);
            }


        }
        [HttpPost]
        public ActionResult Edit(Animal std)
        {




            if (ModelState.IsValid)
            {
                using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
                {
                    int currentAnimal = Convert.ToInt32(Request.Form["EcosystemId"]);//seleccion del combo

                    //consulta a la base

                    var objCustomer = (from q in DBContext.EcosystemSet
                                       where q.EcosystemId == currentAnimal
                                       select q).FirstOrDefault();


                    var u = (from q in DBContext.AnimalSet
                             where q.AnimalId == std.AnimalId
                             select q).FirstOrDefault();

                    if (u != null)
                    {
                        u.NameAnimal = std.NameAnimal;
                        u.SoundAnimal = std.SoundAnimal;
                        u.ImgAnimal = std.ImgAnimal;
                        u.DescAnimal = std.DescAnimal;
                        u.Ecosystem = objCustomer;

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

        private void PopulateCustomers(object selectedAnimal = null)
        {
            EcoGameModelContainer db = new EcoGameModelContainer();
            var customersQuery = from d in db.EcosystemSet
                                 orderby d.NameEcosystem
                                 select d;

            ViewBag.EcosystemID = new SelectList(customersQuery, "EcosystemId", "NameEcosystem", selectedAnimal);


        }

        [HttpPost]
        public ActionResult Create(Animal objOrder)
        {
            EcoGameModelContainer db = new EcoGameModelContainer();
            int currentAnimal = Convert.ToInt32(Request.Form["EcosystemId"]);//seleccion del combo

            //consulta a la base

            var objCustomer = (from q in db.EcosystemSet
                               where q.EcosystemId == currentAnimal
                               select q).FirstOrDefault();

            objOrder.Ecosystem = objCustomer;
            db.AnimalSet.Add(objOrder);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int AnimalId)//consultar el estudainte q deseo borrar
        {
            using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
            //using para usar en este contexto
            {
                var std = (from q in DBContext.AnimalSet
                           where q.AnimalId == AnimalId
                           select q).FirstOrDefault();
                return View(std);
            }
        }

        //POST
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(Animal std)//consultar el estudainte q deseo borrar
        {
            using (EcoGameModelContainer DBContext = new EcoGameModelContainer())
            //using para usar en este contexto
            {
                var u = (from q in DBContext.AnimalSet
                         where q.AnimalId == std.AnimalId
                         select q).FirstOrDefault();

                DBContext.AnimalSet.Remove(u);
                DBContext.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}