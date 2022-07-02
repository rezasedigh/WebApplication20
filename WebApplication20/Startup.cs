using Coravel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Sahra.jobManager;
using Sahra.jobManager.Data;
using System;
using System.Reflection;
using MediatR;
namespace WebApplication20
{
    public class Startup : Program
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var con = Configuration.GetConnectionString("NewMdpContext");
            services.AddDbContext<ApplicationDbContext>(options =>
                                                        options.UseSqlServer(con));

            services.AddScheduler();

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);


            services.AddTransient<SendDailyReportsEmailJob>();
            services.AddTransient<SendEmail>();
            services.AddTransient<SendHello>();

            services.AddHostedService<JobManualTriggerService>();
            services.AddTransient<ILogger<JobManualTriggerService>, Logger<JobManualTriggerService>>();
            services.AddSingleton<MessageRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication20", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication20 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            //        scheduler.Schedule(
            //() => Console.WriteLine("Every minute during the week.")).EveryFiveSeconds();

            //var provider1 = app.ApplicationServices;
            //provider1.UseScheduler(scheduler =>

            //{
            //    scheduler
            //       .Schedule<SendEmail>()
            //            .EveryFiveSeconds();

            //});

            //var provider2 = app.ApplicationServices;
            //provider2.UseScheduler(scheduler =>

            //{
            //    scheduler
            //       .Schedule<SendHellowcs>()
            //            .EveryFiveSeconds();

            //});
        }
    }
}
