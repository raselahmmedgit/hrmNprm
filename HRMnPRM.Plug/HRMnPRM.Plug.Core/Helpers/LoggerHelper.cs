using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HRMnPRM.Plug.Core
{
    public static class LoggerHelper
    {
        public static void LoggerError()
        {
            System.Exception ex = System.Web.HttpContext.Current.Server.GetLastError();
            LoggerError(ex);
        }

        public static void LoggerError(Exception ex)
        {
            var currentContext = HttpContext.Current;

            string logSummery, logDetails, filePath = "No file path found.", url = "No url found to be reported.";

            if (currentContext != null)
            {
                filePath = currentContext.Request.FilePath;
                url = currentContext.Request.Url.AbsoluteUri;
            }

            logSummery = ex.Message;
            logDetails = ex.ToString();

            //-----------------------------------------------------

            string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/log.txt");
            FileStream fStream = new FileStream(path, FileMode.Append, FileAccess.Write);
            BufferedStream bfs = new BufferedStream(fStream);
            StreamWriter sWriter = new StreamWriter(bfs);

            //insert a separator line
            sWriter.WriteLine("=================================================================================================");

            //create log for header
            sWriter.WriteLine(logSummery);
            sWriter.WriteLine("Log time:" + DateTime.Now);
            sWriter.WriteLine("URL: " + url);
            sWriter.WriteLine("File Path: " + filePath);

            //create log for body
            sWriter.WriteLine(logDetails);

            //insert a separator line
            sWriter.WriteLine("=================================================================================================");

            sWriter.Close();

        }

        public static void LoggerInform(string logSummery, string logDetails)
        {
            var currentContext = HttpContext.Current;

            string filePath = "No file path found.", url = "No url found to be reported.";

            if (currentContext != null)
            {
                filePath = currentContext.Request.FilePath;
                url = currentContext.Request.Url.AbsoluteUri;
            }

            //-----------------------------------------------------

            string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/log.txt");
            FileStream fStream = new FileStream(path, FileMode.Append, FileAccess.Write);
            BufferedStream bfs = new BufferedStream(fStream);
            StreamWriter sWriter = new StreamWriter(bfs);

            //insert a separator line
            sWriter.WriteLine("=================================================================================================");

            //create log for header
            sWriter.WriteLine(logSummery);
            sWriter.WriteLine("Log time:" + DateTime.Now);
            sWriter.WriteLine("URL: " + url);
            sWriter.WriteLine("File Path: " + filePath);

            //create log for body
            sWriter.WriteLine(logDetails);

            //insert a separator line
            sWriter.WriteLine("=================================================================================================");

            sWriter.Close();

        }
    }
}
