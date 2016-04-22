using System;
using System.Data.SqlClient;
using System.Web;
using Elmah;

namespace Wheel.Topshelf.Common
{
    public class SyncErrorMailModule : ErrorMailModule
    {
        protected override void ReportErrorAsync(Error error)
        {
            ReportError(error); // force synchronous - otherwise emails are not sent.
        }
    }


    public static class ElmahExtensions
    {
        public static void LogToElmah(this string value)
        {
            var exception = new Exception(value);
            exception.LogToElmah();
        }

        public static void LogToElmah(this Exception ex)
        {
            InitNoContext();
            
            ErrorSignal.Get(_httpApplication).Raise(ex);
        }

        private static HttpApplication _httpApplication;
        private static readonly ErrorFilterConsole ErrorFilter = new ErrorFilterConsole();

        public static SyncErrorMailModule ErrorEmail = new SyncErrorMailModule();
        public static ErrorLogModule ErrorLog = new ErrorLogModule();
        public static ErrorTweetModule ErrorTweet = new ErrorTweetModule();

        private static void InitNoContext()
        {
            _httpApplication = new HttpApplication();
            ErrorFilter.Init(_httpApplication);

            (ErrorEmail as IHttpModule).Init(_httpApplication);
            ErrorFilter.HookFiltering(ErrorEmail);

            (ErrorLog as IHttpModule).Init(_httpApplication);
            ErrorFilter.HookFiltering(ErrorLog);

            (ErrorTweet as IHttpModule).Init(_httpApplication);
            ErrorFilter.HookFiltering(ErrorTweet);
        }

        private class ErrorFilterConsole : ErrorFilterModule
        {
            public void HookFiltering(IExceptionFiltering module)
            {
                module.Filtering += base.OnErrorModuleFiltering;
            }
        }
    }
}