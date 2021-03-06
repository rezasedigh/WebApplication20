using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahra.jobManager.Model
{
    public class crudModelDto
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string InvocableFullPath { get; set; }
        public string CronExpression { get; set; }
        public int EverySecond { get; set; }
        public int EveryMinute { get; set; }
        public int EveryHour { get; set; }
        public string EveryDayofTheWeeks { get; set; }
        public bool PreventOverlapping { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
        public string TimeZoneInfo { get; set; }

    }
}
