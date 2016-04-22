using System.Collections.Generic;
using Hangfire;
using Microsoft.Owin;
using Owin;
using Wheel.Core.Jobs;
using Wheel.Hangfire;

[assembly: OwinStartup(typeof(Startup))]
namespace Wheel.Hangfire
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("Hangfire");

            app.UseHangfireDashboard();
            //app.UseHangfireServer();

            //var _jobs = new List<IJob>() { new BirthDayJob() };

            //foreach (var _job in _jobs)
            //{
            //    RecurringJob.AddOrUpdate(() => _job.Process(), _job.CronSchedule());
            //}
        }
    }
}