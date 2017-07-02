using OwnersPetsVS2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OwnersPetsVS2017.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values        
        public List<OwnerCount> Get()
        {
            return OwnersPetsVS2017.Models.FromToDB.GetOwners();
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]Owner value)
        {
            OwnersPetsVS2017.Models.FromToDB.AddOwner(value.OwnerName);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
    public class DeleteController : ApiController
    {
        // POST api/delete
        public void Post([FromBody]Owner value)
        {
            OwnersPetsVS2017.Models.FromToDB.DeleteOwner(value.OwnerName);
        }
    }
}
