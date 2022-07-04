using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShineServices
{
    public static class Logger
    {
        public static string LogFilePath = "Logs\\Logs " + DateTime.Now.ToString("yyyy MM dd") + ".txt";

        /// <summary>
        ///  
        /// </summary>
        /// <param name="Logs"></param>
        public static void WriteLogs(string Logs, bool withHeader = true)
        {
            string logs = "\r\n" +
                "-------------------------------------";
                
            if (withHeader) { logs += "\r\n[DT]" + DateTime.Now.ToString() + "[]"; }
            logs += Logs;
            if (withHeader) { logs += "[]"; }
            ///////////////////////////////////
            Write(logs);
        }


        public static void WriteException(Exception Exc, string Logs = "", bool withHeader = true)
        {
            string logs = "\r\n" +
                "-------------------------------------" +
                "\r\n";
            if (withHeader) { logs += "\r\n\r\n[DT]" + DateTime.Now.ToString() + "[]"; }
            logs += Logs;
            if (withHeader) { logs += "[]\r\nMessage[]\r\n"; }
            logs += Exc.Message;
            if (withHeader) { logs += "[]\r\nStackTrace[]\r\n"; }
            logs += Exc.StackTrace;
            if (withHeader) { logs += "[]\r\n"; }

            ///////////////////////////////////
            Write(logs);
        }




        static void Write(string Logs)
        {
            try
            {
                File.AppendAllText(LogFilePath, Logs);
            }
            catch
            {
                ScalarFuntions.SetTimeout(() =>
                {
                    try
                    { File.AppendAllText(LogFilePath, Logs); }
                    catch
                    {
                        ScalarFuntions.SetTimeout(() =>
                        {
                            try
                            { File.AppendAllText(LogFilePath, Logs); }
                            catch
                            {
                                ScalarFuntions.SetTimeout(() =>
                                {
                                    try { File.AppendAllText(LogFilePath, Logs); } catch { }
                                }, 60000);
                            }
                        }, 15000);
                    }

                }, 5000);
            }
        }

    }
}
