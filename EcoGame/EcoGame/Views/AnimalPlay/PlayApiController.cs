using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace EcoGame.Views.AnimalPlay
{
    public class PlayApiController : ApiController
    {
        EcoGameModelContainer emd;

        public PlayApiController()
        {
            emd = new EcoGameModelContainer();
        }

        [Route("EmployeeList")]
        public IEnumerable<Animal> GetEmployee()
        {

            var studentList = new List<Animal>
            {
                new Animal(){
                    AnimalId =1,
                    NameAnimal = "Juan",
                    },
                new Animal(){
                    AnimalId =1,
                    NameAnimal = "Juan",
                    }


            };
            return studentList;
        }

    }
}
