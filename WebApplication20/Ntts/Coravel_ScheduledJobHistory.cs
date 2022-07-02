using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahra.jobManager.Ntts
{
    public class Coravel_ScheduledJobHistory
    {
        public int Id { get; set; }

        public DateTime EndedAt { get; set; }

        public string TypeFullPath { get; set; }

        public string DisplayName { get; set; }

        public bool Failed { get; set; }

        public string ErrorMessage { get; set; }

        public string StackTrace { get; set; }
    }
}
