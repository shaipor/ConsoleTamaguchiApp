using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTamaguchiApp.DataTransferObjects
{

    public class PetsDTO

    {
        public int petId { get; set; }
        public string petName { get; set; }
        public string userName { get; set; }
        public double petWeight { get; set; }
        public DateTime BirthDate { get; set; }
        public int HungerLevel { get; set; }
        public int HygieneLevel { get; set; }
        public int HappinesLevel { get; set; }
        public int lifeCycleId { get; set; }


        public PetsDTO() { }
    }
    
}
