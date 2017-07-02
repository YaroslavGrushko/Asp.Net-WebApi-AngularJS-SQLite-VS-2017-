using OwnersPetsVS2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OwnersPetsVS2017.Controllers
{
    public class PetValuesController : ApiController
    {
        // GET: api/PetValues

        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET: api/PetValues/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PetValues
        public void Post([FromBody]PetOwner value)
        {
            OwnersPetsVS2017.Models.FromToDB.AddPet(value);
        }

        // PUT: api/PetValues/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PetValues/5
        public void Delete(int id)
        {
        }
    }
    public class GetPetsController : ApiController
    {
        // POST: api/GetPets
        public List<string> Post([FromBody]Owner value)
        {
          return  OwnersPetsVS2017.Models.FromToDB.GetPets(value.OwnerName);
        }

    }
    public class DeletePetController : ApiController
    {
        // POST: api/DeletePet
        public void Post([FromBody]PetOwner value)
        {
            OwnersPetsVS2017.Models.FromToDB.DeletePet(value);
        }

    }
}
