using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OwnersPetsVS2017.Models
{
    public class PetOwner
    {
        public PetOwner(String OwnerName,String PetName) {
            this.OwnerName = OwnerName;
            this.PetName = PetName;
        }
        public string OwnerName { get; set; }
        public string PetName { get; set; }

    }
    public class OwnerCount
    {
        public OwnerCount(String OwnerName, int petCount)
        {
            this.OwnerName = OwnerName;
            this.petCount = petCount;
        }
        public string OwnerName { get; set; }
        public int petCount { get; set; }

    }
}