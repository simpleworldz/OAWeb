using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApp.Models;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //保存日志
            string fileLogPath = Server.MapPath("/Log/");

            ThreadPool.QueueUserWorkItem((a) =>
            {
                //这个不能忘
                while (true)
                {
                    if (MyExceptionAttribute.exceptionQueue.Count > 0)
                    {
                        Exception ex = MyExceptionAttribute.exceptionQueue.Dequeue();
                        string FileName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                        System.IO.File.AppendAllText(fileLogPath + FileName, ex.ToString(), System.Text.Encoding.Default);

                    }
                    else
                    {
                        Thread.Sleep(3000);
                    }
                }
            },fileLogPath);
        }
    }
}
