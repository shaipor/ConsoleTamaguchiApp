﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTamaguchiApp.DataTransferObjects
{
    public class PlayerDTO
    {
        public string UserName { get; set; }
        public string PlayerName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        
       
        public PlayerDTO() { }
      
    }
}
