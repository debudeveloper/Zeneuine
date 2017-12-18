using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityBusiness;

namespace ErrorHandling
{
    public class LogWriter
    {
        public static string CreateErrorMessage(Exception serviceException)
        {
            StringBuilder messageBuilder = new StringBuilder();
            try
            {
                messageBuilder.AppendLine("The Exception is:-");

                messageBuilder.AppendLine("Exception :: " + serviceException.ToString());
                if (serviceException.InnerException != null)
                {
                    messageBuilder.AppendLine("InnerException :: " + serviceException.InnerException.ToString());
                }
                return messageBuilder.ToString();
            }
            catch
            {
                messageBuilder.AppendLine("Exception:: Unknown Exception.");
                return messageBuilder.ToString();
            }

        }
        public static void LogFileWrite(string message,string path=null)
        {
            FileStream fileStream = null;
            StreamWriter streamWriter = null;

            if(path == null)
            {
                path = "c:\\LogError\\";
            }

            try
            {
                
                path = path + "ProgramLog" + "-" + DateTime.Today.ToString("yyyyMMdd") + "." + "txt";

                if (path.Equals("")) return;
                #region Create the Log file directory if it does not exists 
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo = new FileInfo(path);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                #endregion Create the Log file directory if it does not exists

                if (!logFileInfo.Exists)
                {
                    fileStream = logFileInfo.Create();
                }
                else
                {
                    fileStream = new FileStream(path, FileMode.Append);
                }
                streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(message);
            }
            finally
            {
                if (streamWriter != null) streamWriter.Close();
                if (fileStream != null) fileStream.Close();
            }

        }
    }
}
