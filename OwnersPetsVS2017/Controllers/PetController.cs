using OwnersPetsVS2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OwnersPetsVS2017.Controllers
{[RoutePrefix("Pet")]
    public class PetController : Controller
    {
        // GET: Pet
        [Route("pet")]
        public ActionResult Index(String ownername)
        {         
                ViewBag.Title = "Owners";
            Owner owner = new Owner();
            owner.OwnerName = ownername;
            return View("pet", owner);
        }
    }
}