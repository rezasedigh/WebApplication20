using Coravel;
using Coravel.Invocable;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sahra.jobManager.entity;
using Sahra.jobManager.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Coravel.Scheduling.Schedule.Interfaces;
using WebApplication20;
using Sahra.jobManager.Enum;

namespace Sahra.jobManager
{
    public class JobManualTriggerService : BackgroundService
    {
     
        //server=YOURSERVER;user=YOURUSERID;password=YOURPASSWORD;database=YOURDATABASE
        private readonly MessageRepository _messageRepository;
        private readonly IServiceScopeFactory _serviceScopefactory;
        public JobManualTriggerService(MessageRepository messageRepository,
                              IServiceScopeFactory serviceScopefactory)
        {
            _messageRepository = messageRepository;
            _serviceScopefactory = serviceScopefactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var jobList = Enumerable.Range(0, 5).Select(x => Task.Run(() => DoJob(stoppingToken), stoppingToken));
            await Task.WhenAll(jobList);

        }

        private async Task DoJob(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {

                    if (_messageRepository.RunningJobs.TryTake(out string jobName))
                    {


                        var type = typeof(IInvocable);
                        var types = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(s => s.GetTypes())
                            .Where(p => type.IsAssignableFrom(p));

                        var className = types.FirstOrDefault(x => x.Name == jobName);
                        var history = new Coravel_JobHistoryEntity
                        {
                            DisplayName = className.Name,
                            TypeFullPath = className.FullName
                        };

                        using var serviceScope = _serviceScopefactory.CreateScope();
                        var serviceProvider = serviceScope.ServiceProvider.GetRequiredService<IServiceProvider>();
                        var service = serviceProvider.GetService(className);

                        if (service is not null)
                        {
                            var ct = service as IInvocable;

                            try
                            {
                                history.StartedAt = DateTime.Now;

                                await ct.Invoke();

                                history.EndedAt = DateTime.Now;
                            }
                            catch (Exception ex)
                            {
                                using var loggerScope = _serviceScopefactory.CreateScope();
                                var logger = serviceScope.ServiceProvider.GetRequiredService<Logger<JobManualTriggerService>>();
                                logger.LogError(ex, ex.Message);
                                history.StackTrace = ex.StackTrace;
                                history.ErrorMessage = ex.Message;
                                history.Failed = true;
                            }


                            using var scope = _serviceScopefactory.CreateScope();
                            var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                            _context.JobHistoryEntity.Add(history);
                            await _context.SaveChangesAsync(cancellationToken);

                        }
                    }
                }
                catch
                {

                }

            }

        }

    }
  
    public class StartupServices : BackgroundService
    {
        
 
        private readonly IServiceScopeFactory _serviceScopefactory;
        private readonly IScheduler _scheduler;
        public StartupServices(IServiceScopeFactory serviceScopefactory, IScheduler scheduler)
        {
            _serviceScopefactory = serviceScopefactory;
            _scheduler = scheduler;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var factory = _serviceScopefactory.CreateAsyncScope();
            var dbContext = factory.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var ScheduledJobs = await dbContext.ScheduledJobsEntity.Where(x => x.Active).ToListAsync();
            var type = typeof(IInvocable);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            

            foreach (var schedulejob in ScheduledJobs)
            {
                
                var className = types.FirstOrDefault(x => x.Name == schedulejob.Name);

                if (schedulejob.EverySecond > 0)
                {
                   _scheduler.ScheduleInvocableType(className).EverySeconds(schedulejob.EverySecond);
                }
                if (schedulejob.EveryMinute > 0)
                {
                    _scheduler.ScheduleInvocableType(className).Cron($"*/{schedulejob.EveryMinute} * * * *");
                }
                if (!string.IsNullOrEmpty(schedulejob.EveryDayofTheWeeks))
                { 
                    
                    var weeks = schedulejob.EveryDayofTheWeeks.Split(",");
                    if (weeks.Any())
                    {
                        foreach (var day in weeks)
                        {
                            if (day == EnumWeeks.Saturday.ToString())
                            {
                                _scheduler.ScheduleInvocableType(className).Weekly().Saturday();

                            }
                            if (day == EnumWeeks.Sunday.ToString())
                            {
                                _scheduler.ScheduleInvocableType(className).Weekly().Sunday();

                            }
                            if (day == EnumWeeks.Monday.ToString())
                            {
                                _scheduler.ScheduleInvocableType(className).Weekly().Monday();

                            }
                            if (day == EnumWeeks.Tuesday.ToString())
                            {
                                _scheduler.ScheduleInvocableType(className).Weekly().Tuesday();

                            }
                            if (day == EnumWeeks.Wednesday.ToString())
                            {
                                _scheduler.ScheduleInvocableType(className).Weekly().Wednesday();

                            }
                            if (day == EnumWeeks.Thursday.ToString())
                            {
                                _scheduler.ScheduleInvocableType(className).Weekly().Thursday();

                            }
                            if (day == EnumWeeks.Friday.ToString())
                            {
                                _scheduler.ScheduleInvocableType(className).Weekly().Friday();

                            }

                        }
                    }     
                }
            }

        }
    }
} 


