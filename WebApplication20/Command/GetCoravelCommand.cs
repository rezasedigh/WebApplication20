using MediatR;
using Microsoft.EntityFrameworkCore;
using Sahra.jobManager.Model;
using Sahra.jobManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sahra.jobManager.Command
{
    public class GetCoravelCommand:IRequest<crudModelResponse>
    {
        private readonly int Id;

        public GetCoravelCommand(int id)
        {
            Id = id;
        }

        public class GetCoravelHandler : IRequestHandler<GetCoravelCommand, crudModelResponse>
        {
            private readonly ApplicationDbContext _context;

            public GetCoravelHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<crudModelResponse> Handle(GetCoravelCommand request, CancellationToken cancellationToken)
            {
                var query =  _context.ScheduledJobsEntity.AsNoTracking().Where(x => x.Id == request.Id).Select(x => new crudModelResponse
                {
                    Id = x.Id,
                    Name=x.Name,
                    FullName=x.FullName,
                    InvocableFullPath = x.Name,
                    CronExpression = x.CronExpression,
                    EverySecond = x.EverySecond,
                    EveryMinute = x.EveryMinute,
                    EveryHour = x.EveryHour,
                    EveryDayofTheWeeks = x.EveryDayofTheWeeks,
                    PreventOverlapping = x.PreventOverlapping,
                    CreatedAt = x.CreatedAt,
                    Active = x.Active,
                    TimeZoneInfo = x.TimeZoneInfo
                });

                var nav = await query.FirstOrDefaultAsync(cancellationToken);
                return nav;
            }
        }
    }
}
