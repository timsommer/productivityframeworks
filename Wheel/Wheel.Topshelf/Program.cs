using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Topshelf;
using Topshelf.Common.Logging;
using Wheel.Topshelf.Infrastructure;

namespace Wheel.Topshelf
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        static void Main(string[] args)
        {
            Log.Info("Starting TopshelfService");

            HostFactory.Run(x =>
            {
                x.SetServiceName("WheelTopshelfService");
                x.SetDisplayName("WheelTopshelfService");
                x.SetDescription("Wheel project Topshelf Service");
                x.RunAsNetworkService();
                x.StartAutomaticallyDelayed();
                x.UseCommonLogging();
                //x.UseAutofacContainer(((AutofacContainer)_container).InnerContainer);
                x.Service<Infrastructure.WheelService>(s =>
                {
                    s.ConstructUsing(c => new WheelService());
                    //s.ConstructUsingAutofacContainer();
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
            });
        }
    }
}
