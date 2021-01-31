﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTamaguchiApp.DataTransferObjects
{
    public class PlayerDTO
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerFamilyName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public PlayerDTO() { }
    }
}
