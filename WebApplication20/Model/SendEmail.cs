using Coravel.Invocable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication20
{
    public class SendEmail : IInvocable
    {
        public async Task Invoke()
        {
            Console.WriteLine("Hello world2");
            await Task.CompletedTask;
        }
    }
}
