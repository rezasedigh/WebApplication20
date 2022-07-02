using FluentAssertions.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sahra.jobManager.Model;
using Sahra.jobManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sahra.jobManager.Command
{
    public class DeleteCoravelCommand : IRequest
    {
        private readonly int Id;

        public DeleteCoravelCommand(int id)
        {

            Id = id;
        }
        public class DeleteHandler : AsyncRequestHandler<DeleteCoravelCommand>
        {
            private readonly ApplicationDbContext _context;
            private readonly ILogger<DeleteCoravelCommand> _logger;

            public DeleteHandler(ApplicationDbContext context , ILogger<DeleteCoravelCommand> logger)
            {
                _context = context;
                _logger = logger;

            }

            protected async override Task Handle(DeleteCoravelCommand request, CancellationToken cancellationToken)
            {
                var exist = await _context.ScheduledJobsEntity.AnyAsync(x => x.Id == request.Id);
                var nav = await _context.ScheduledJobsEntity.Where(p => p.Id == request.Id).SingleOrDefaultAsync();
                _context.ScheduledJobsEntity.Remove(nav);
                await _context.SaveChangesAsync(cancellationToken);
               
             }

        }

    }

}
