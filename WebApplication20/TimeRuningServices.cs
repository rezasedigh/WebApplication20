using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sahra.jobManager;
using Sahra.jobManager.Data;
using Sahra.jobManager.Ntts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sahra.jobManager
{
    public class TimeRuningServices : IRequest

    {
        //private readonly Coravel_ScheduledJobs Filter;
        //public TimeRuningServices(Coravel_ScheduledJobs filter)
        //{
        //    Filter = filter;          
        //}
        internal class TimeRuningServicesHandler : AsyncRequestHandler<TimeRuningServices>
        {
            private readonly ApplicationDbContext _context;

            public TimeRuningServicesHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            protected async override Task Handle(TimeRuningServices request, CancellationToken cancellationToken)
            {
                var query = from s in _context.ScheduledJobsEntity
                            select new Coravel_ScheduledJobs
                            {
                                Id = s.Id,
                                Name=s.Name,
                                FullName=s.FullName,
                                InvocableFullPath = s.Name,
                                CronExpression = s.CronExpression,
                                EverySecond = s.EverySecond,
                                EveryMinute = s.EveryMinute,
                                EveryHour = s.EveryHour,
                                EveryDayofTheWeeks = s.EveryDayofTheWeeks,
                                PreventOverlapping = s.PreventOverlapping,
                                CreatedAt = s.CreatedAt,
                                Active = s.Active,
                                TimeZoneInfo = s.TimeZoneInfo
                            };

                await Task.FromResult(query);
            }
        }
    }
}
