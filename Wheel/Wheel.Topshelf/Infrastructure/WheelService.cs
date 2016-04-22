using Hangfire;
using log4net;
using Wheel.Topshelf.Common;

namespace Wheel.Topshelf.Infrastructure
{
    public class WheelService
    {
        private ILog _Log = LogManager.GetLogger("WheelService");
        private BackgroundJobServer _Server;

        public WheelService()
        {
            //hangvuur
            GlobalConfiguration.Configuration.UseSqlServerStorage("Hangfire");

        }

        public void Start()
        {
            _Log.InfoFormat("Starting Service");
            "Starting Service".LogToElmah();


            //hangvuur
            _Server = new BackgroundJobServer();
            JobsStore.RegisterJobs();
        }

        public void Stop()
        {
            _Log.InfoFormat("Stopping Service");
            "Stopping Service".LogToElmah();
        }
    }
}