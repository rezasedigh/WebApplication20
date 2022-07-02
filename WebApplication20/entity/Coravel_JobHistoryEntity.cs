using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahra.jobManager.entity
{
    public class Coravel_JobHistoryEntity
    {
        public int ID { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public string TypeFullPath { get; set; }
        public string DisplayName { get; set; }
        public bool Failed { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }

    

}
}
