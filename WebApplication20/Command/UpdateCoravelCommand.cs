using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Sahra.jobManager.Model;
using Sahra.jobManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sahra.jobManager.Command
{
    public class UpdateCoravelCommand:IRequest
    {
        private readonly crudModelResponse Model;
       
        public UpdateCoravelCommand(crudModelResponse model)
        {
            Model = model;
        }
        public class UpdateCoravelHandler : AsyncRequestHandler<UpdateCoravelCommand>
        {
               
          private readonly ApplicationDbContext _context;
              public UpdateCoravelHandler(ApplicationDbContext context)
                {
                   _context = context;
                }


            protected async override Task Handle(UpdateCoravelCommand request, CancellationToken cancellationToken)
            {
                var nav = await _context.ScheduledJobsEntity.Where(p => p.Id == request.Model.Id).FirstOrDefaultAsync();

                nav.Name = request.Model.InvocableFullPath;
                nav.FullName = request.Model.InvocableFullPath;
                nav.CronExpression = request.Model.CronExpression;
                nav.EverySecond = request.Model.EverySecond;
                nav.EveryMinute = request.Model.EveryMinute;
                nav.EveryHour = request.Model.EveryHour;
                nav.EveryDayofTheWeeks = request.Model.EveryDayofTheWeeks;
                nav.PreventOverlapping = request.Model.PreventOverlapping;
                nav.Active = request.Model.Active;
                nav.TimeZoneInfo = request.Model.TimeZoneInfo;

                await _context.SaveChangesAsync();

            }

            
            

            
        }
        
    }
}
