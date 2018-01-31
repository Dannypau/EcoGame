using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//libreria para los view models
using EcoGame.ViewModels;

namespace EcoGame.Controllers
{
    public class AnimalEcosystemDetailController : Controller
    {
        // GET: AnimalEcosystemDetail
        public ActionResult Index()
        {
            EcoGameModelContainer DB = new EcoGameModelContainer();
            List<AnimalVM> AnimalVMList = new List<AnimalVM>();

            var AnimalList = (from Ani  in DB.AnimalSet join Eco in DB.EcosystemSet on Ani.Ecosystem.EcosystemId equals Eco.EcosystemId
                              select new
                              {
                                  Ani.AnimalId,
                                  Ani.NameAnimal,
                                  Ani.ImgAnimal,
                                  Ani.SoundAnimal,
                                  Ani.DescAnimal,
                                  Eco.NameEcosystem


                                  

                              }
                              ).ToList();
            
            foreach(var item  in AnimalList)
            {
                AnimalVM objcvm = new AnimalVM();
                objcvm.AnimalId = item.AnimalId;
                objcvm.NameAnimal = item.NameAnimal;
                objcvm.ImgAnimal = item.ImgAnimal;
                objcvm.SoundAnimal = item.SoundAnimal;
                objcvm.DescAnimal = item.DescAnimal;
                objcvm.NameEcosystem = item.NameEcosystem;

                AnimalVMList.Add(objcvm);


            }
            return View(AnimalVMList);
        }


        
    }
}