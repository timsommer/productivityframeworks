using System;
using System.Linq;
using Hangfire;
using log4net;

namespace Wheel.Core.Jobs
{
    public interface IJob
    {
        void Process();

        string CronSchedule();
    }

    public class BirthDayJob : IJob
    {
        private ILog _Log = LogManager.GetLogger(typeof (BirthDayJob).Name);

        public void Process()
        {
            using (var _context = new WheelContext())
            {
                var _employees = _context.Employees.ToList();

                foreach (var _employee in _employees)
                {
                    if (!_employee.BirthDay.HasValue)
                    {
                        _Log.ErrorFormat("Birthday is required for this job!");
                        throw new Exception("Birthday is required!");
                    }

                    var _now = DateTime.Now;

                    if (_employee.BirthDay.Value.Day == _now.Day && _employee.BirthDay.Value.Month == _now.Month)
                    {
                        _Log.InfoFormat("It is {0}'s birthday, you'll propably want to do somethign now!",
                            _employee.FirstName);
                        //Hurraaaaaaay
                    }
                    else
                    {
                        _Log.DebugFormat("{0} does not have a birthday today. Doing skippy skipps skipping stuff!", _employee.FirstName);
                    }
                }
            }
        }

        public string CronSchedule()
        {
            return Cron.Hourly(30);
        }
    }
}