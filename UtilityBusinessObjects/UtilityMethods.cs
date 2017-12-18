using EntityDataAccess.Core;
using EntityDataAccess.GenericRepository;
using EntityObjects.Objects;
using EntityObjects.UtilityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Data.Entity;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Dynamic;
using System.Runtime.Caching;
using System.Configuration;
using System.Text;
using Twilio;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Globalization;

namespace UtilityBusiness
{
    public static class UtilityMethods
    {
        public static string DecodeFrom64(string encodedData)
        {
            try
            {
                var output = encodedData;
                //switch (output.Length % 4) // Pad with trailing '='s
                //{
                //    case 0:
                //        break; // No pad chars in this case
                //    case 2:
                //        output += "==";
                //        break; // Two pad chars
                //    case 3:
                //        output += "=";
                //        break; // One pad char
                //    default:
                //        throw new FormatException("Illegal base64url string!");
                //}

                var e = Encoding.GetEncoding("iso-8859-1");
                byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);

                string returnValue = e.GetString(encodedDataAsBytes);

                if (IsAscii(returnValue))
                    return returnValue;

                return encodedData;
            }
            catch (Exception ex)
            {
                return encodedData;
            }
        }

        public static bool IsAscii(string value)
        {
            // ASCII encoding replaces non-ascii with question marks, so we use UTF8 to see if multi-byte sequences are there
            return Encoding.UTF8.GetByteCount(value) == value.Length;
        }

        public static DateTime GetSqlMinDateTime()
        {
            return DateTime.Parse(System.Data.SqlTypes.SqlDateTime.MinValue.ToString());
        }
        public static string DescriptionAttr<T>(this T source)
        {
            if (source == null)
                return "";

            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

 
        public static Type GetTypeOfObject(string enumName)
        {
            var type = Type.GetType("EntityObjects.UtilityObjects." + enumName + "Enum, EntityObjects");
            if (type == null)
            {
                type = Type.GetType("EntityObjects.UtilityObjects." + enumName + ", EntityObjects");
            }
            if (type == null)
            {
                type = Type.GetType("EntityObjects.UtilityObjects.HealthEnum." + enumName + ", EntityObjects");
            }
            if (type == null)
            {
                type = Type.GetType("EntityObjects.UtilityObjects.LoanEnum." + enumName + ", EntityObjects");
            }
            if (type == null)
            {
                type = Type.GetType("EntityObjects.UtilityObjects.PPIEnum." + enumName + ", EntityObjects");
            }
            return type;
        }
        public static string Base64DecodeStripped(string encodedData)
        {
            try
            {
                var output = encodedData;
                switch (output.Length % 4) // Pad with trailing '='s
                {
                    case 0:
                        break; // No pad chars in this case
                    case 2:
                        output += "==";
                        break; // Two pad chars
                    case 3:
                        output += "=";
                        break; // One pad char
                    default:
                        throw new FormatException("Illegal base64url string!");
                }
                var converted = Convert.FromBase64String(output); // Standard base64 decoder             
                var returnValue = Encoding.UTF8.GetString(converted);
                return returnValue;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }
        public static string Base64EncodeStripped(string data)
        {
            var concateString = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(concateString).TrimEnd('='); //remove padding (==)          
        }



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

        public static void LogFileWrite(string message, string path = null)
        {
            FileStream fileStream = null;
            StreamWriter streamWriter = null;

            if (path == null)
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


        public static string GenerateRandomString(int length = 4)
        {
            Random random = new Random();
            string str = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            string randomAlphaNumeric = new string(Enumerable.Repeat(str, length)
           .Select(s => s[random.Next(s.Length)]).ToArray());
            randomAlphaNumeric.GetHashCode();

            return randomAlphaNumeric;
        }

    }




}
