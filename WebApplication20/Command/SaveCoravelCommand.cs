using MediatR;
using Sahra.jobManager.entity;
using Sahra.jobManager.Model;
using Sahra.jobManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sahra.jobManager.Command
{
    public class SaveCoravelCommand:IRequest
    {
        private readonly crudModelDto Model;
        public SaveCoravelCommand(crudModelDto model)
        {
            Model = model;
        }

        public class SaveCoravelHandle : AsyncRequestHandler<SaveCoravelCommand>
        {
            private readonly ApplicationDbContext _context;

            public SaveCoravelHandle(ApplicationDbContext context)
            {
                _context = context;
            }

            protected async override Task Handle(SaveCoravelCommand request, CancellationToken cancellationToken)
            {
                var entity = new Coravel_ScheduledJobsEntity()
                {
                    Name = request.Model.InvocableFullPath,
                    FullName=request.Model.InvocableFullPath,
                    CronExpression = request.Model.CronExpression,
                    EverySecond = request.Model.EverySecond,
                    EveryMinute = request.Model.EveryMinute,
                    EveryHour = request.Model.EveryHour,
                    EveryDayofTheWeeks = request.Model.EveryDayofTheWeeks,
                    PreventOverlapping = request.Model.PreventOverlapping,
                    CreatedAt = request.Model.CreatedAt,
                    Active = request.Model.Active,
                    TimeZoneInfo = request.Model.TimeZoneInfo

                };

                await _context.ScheduledJobsEntity.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync();
            }
        }
    }
}
