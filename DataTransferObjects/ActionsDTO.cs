﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTamaguchiApp.DataTransferObjects
{
    public class ActionsDTO
    {
        //danielle
        public int actionId { get; set; }
        public string actionName { get; set; }
        public int actionTypeId { get; set; }
        public int actionEffection { get; set; }

        public ActionsDTO() { }
     }
}
