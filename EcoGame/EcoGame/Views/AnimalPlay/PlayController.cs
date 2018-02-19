using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcoGame.Views.AnimalPlay
{
    public class PlayController : Controller
    {
        EcoGameModelContainer Db = new EcoGameModelContainer();
        // GET: Play
        public ActionResult Index()
        {
            
            return View();
         
        }

        // GET: Play
        public ActionResult Cuyabeno()
        {
            var EcosystemName = "Cuyabeno";
            var std = (from q in Db.EcosystemSet
                       where q.NameEcosystem == EcosystemName
                       select q).FirstOrDefault();
            return View(std);
           
        }


        // GET: Play
        public ActionResult Manglar()
        {
            var EcosystemName = "Manglar";
            var std = (from q in Db.EcosystemSet
                       where q.NameEcosystem == EcosystemName
                       select q).FirstOrDefault();
            return View(std);
           
        }

        // GET: Play
        public ActionResult Chimborazo()
        {
            var EcosystemName = "Chimborazo";
            var std = (from q in Db.EcosystemSet
                       where q.NameEcosystem == EcosystemName
                       select q).FirstOrDefault();
            return View(std);

            
        }

        // GET: Play
        public ActionResult Mataje()
        {
            var EcosystemName = "Mataje";
            var std = (from q in Db.EcosystemSet
                       where q.NameEcosystem == EcosystemName
                       select q).FirstOrDefault();
            return View(std);
            
        }





    }
}