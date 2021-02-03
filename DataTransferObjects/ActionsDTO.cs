using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTamaguchiApp.DataTransferObjects
{
    class ActionsDTO
    {
        public int actionId { get; set; }
        public string actionName { get; set; }
        public int actionTypeId { get; set; }
        public int actionEffection { get; set; }

        public ActionsDTO() { }
    }
}
