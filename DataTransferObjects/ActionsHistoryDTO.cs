using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTamaguchiApp.DataTransferObjects
{
    class ActionsHistoryDTO
    {
        public int historyId { get; set; }

        public string userName { get; set; }
        public int petId { get; set; }
        public int actionId { get; set; }

        public DateTime actionTime { get; set; }
        public int lifeCycleId { get; set; }
        public int petAge { get; set; }
        public int statusId { get; set; }
        public int hungerLevel { get; set; }
        public int happinesLevel { get; set; }
        public int hygieneLevel { get; set; }
        public string actionName { get; set; }
        public int actionTypeId { get; set; }
        public int actionEffection { get; set; }

        public ActionsHistoryDTO() { }
    }
}
