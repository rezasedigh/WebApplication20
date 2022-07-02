using System;

namespace Sahra.jobManager.entity
{
    public class Coravel_ScheduledJobHistoryEntity
    {
        public int Id { get; set; }

        public DateTime? EndedAt { get; set; }

        public string TypeFullPath { get; set; }

        public string DisplayName { get; set; }

        public bool? Failed { get; set; }

        public string ErrorMessage { get; set; }

        public string StackTrace { get; set; }
    }
}
