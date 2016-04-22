using System.Collections.Generic;
using Hangfire;
using Wheel.Core.Jobs;

namespace Wheel.Topshelf.Infrastructure
{
    public class JobsStore
    {
        public static void RegisterJobs()
        {
            var _jobs = new List<IJob> {new BirthDayJob()};

            foreach (var _job in _jobs)
            {
                RecurringJob.AddOrUpdate(() => _job.Process(), _job.CronSchedule());
            }
        }
    }
}