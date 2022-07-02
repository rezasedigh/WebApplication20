using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahra.jobManager
{
    public class MessageRepository
    {
        public BlockingCollection<string> RunningJobs { get; private set; }
        public MessageRepository()
        {
            RunningJobs = new BlockingCollection<string>();
        }
    }
}
