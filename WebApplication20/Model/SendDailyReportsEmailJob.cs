using Coravel.Invocable;
using System;
using System.Threading.Tasks;

namespace WebApplication20
{
    public class SendDailyReportsEmailJob : IInvocable
    {
        public async Task Invoke()
        {
            Console.WriteLine("Hello world");
            await Task.CompletedTask;
        }
    }
}
