using Coravel.Invocable;
using Coravel.Scheduling.Schedule.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sahra.jobManager;
using Sahra.jobManager.Command;
using Sahra.jobManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication20.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IScheduler _scheduler;
        private readonly ILogger<HomeController> _logger;
        private readonly MessageRepository _messageRepository;
        private readonly IMediator _mediator;


        public HomeController(ILogger<HomeController> logger,
                              MessageRepository messageRepository, IMediator mediator, IScheduler scheduler)
        {
            _logger = logger;
            _messageRepository = messageRepository;
            _mediator = mediator;
            _scheduler = scheduler;
        }

        [Route("DynamicJobRunner")]
        [HttpPost]
        public IActionResult DynamicJobRunner(string model)
        {
            _messageRepository.RunningJobs.TryAdd(model);
            return Ok();
        }

        [Route("ClassList")]

        [HttpGet]

        public List<string> ClassList()
        {
            var classList = new List<string>();
            var type = typeof(IInvocable);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            var newtypes = types.Where(x => x.FullName != "Coravel.Invocable.IInvocable");
            foreach (var item in newtypes)
            {
                classList.Add(item.FullName);
            }

            return classList;
        }


        [HttpPost("save")]
        public async Task saveCoravel([FromBody] crudModelDto save)
        {
            await _mediator.Send(new SaveCoravelCommand(save));
        }

        [HttpGet]
        public async Task<crudModelResponse> getCoravel(int id)
        {
            return await _mediator.Send(new GetCoravelCommand(id));
        }
        [HttpPut]
        public async Task UpdateCoravel(crudModelResponse update)
        {
            await _mediator.Send(new UpdateCoravelCommand(update));
        }

        [HttpDelete]

        public async Task Delete(int id)
        {
            await _mediator.Send(new DeleteCoravelCommand(id));

        }

        [HttpGet("GetAll")]

        public async Task GetAllProfiles()
        {
            await _mediator.Send(new TimeRuningServices());
        }









    }
}
