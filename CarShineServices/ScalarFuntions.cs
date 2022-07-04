using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CarShineServices
{
    public class ScalarFuntions
    {

        /// <summary>
        /// Gets First Regex Match from string set.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetFirstRegexMatch(string pattern, string text)
        {
            if (isMatchRegex(text, pattern))
                return Regex.Matches(text, pattern, RegexOptions.IgnoreCase)[0].Value ?? "";
            else return "";
        }

        /// <summary>
        /// Check if a string character matches a regex pattern
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool isMatchRegex(string text, string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return true;
            return Regex.IsMatch(text, pattern);
        }

        private static readonly Random random = new Random();
        /// <summary>
        /// Get a Random String Character w.r.t Length Provided
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GetRandomString(int Length = 10)
        {
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", Length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Sees if Google is pingable or not 
        /// </summary>
        public static bool IsInternetConnected
        {
            get
            {
                string host = "google.com";
                bool result = false;
                Ping p = new Ping();
                try
                {
                    PingReply reply = p.Send(host, 5000);
                    if (reply.Status == IPStatus.Success)
                        return true;
                }
                catch { return false; }
                return result;
            }
        }

        /// <summary>
        /// Becomes Stubborn while deleting a file
        /// </summary>
        /// <param name="fullPath"></param>
        public static void DeleteFile(string fullPath)
        {
            try
            {
                File.Delete(fullPath);
            }
            catch { DeleteFile(fullPath); }
        }

        /// <summary>
        /// Create a Folder in C Users Local Temp :-)<br/>
        /// It has \ at end of the path 
        /// </summary>
        public static string EnsureTempFolder
        {
            get
            {
                //if (!Directory.Exists(Path.GetTempPath() + "FinancialSuite"))
                //    Directory.CreateDirectory(Path.GetTempPath() + "FinancialSuite");
                //   return Path.GetTempFileName() + "FinancialSuite\\";
                if (!Directory.Exists(Environment.CurrentDirectory + "\\" + "Cache\\"))
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\" + "Cache\\");
                return Environment.CurrentDirectory + "\\" + "Cache\\";
            }
        }

        internal static string EOLicenseString
        {
            get
            {
                return "Kb114+30EO2s3OmxGeCm3MGz8M5nzunz7fGo7vf2HaF3s7P9FOKe5ff2EL112PD9GvZ3s+X1D5+t8PT26KF+xrLUE/Go5Omzy5+v3PYEFO6ntKbC461pmaTA6bto2PD9GvZ3s/MDD+SrwPL3Gp+d2Pj26KFpqbPC3a5rp7XIzZ+v3PYEFO6ntKbC46FotcAEFOan2PgGHeR36d7SGeWawbMKFOervtrI9eBysO3XErx2s7MEFOan2PgGHeR3s7P9FOKe5ff26XXj7fQQ7azcws0X6Jzc8gQQyJ21tMbbtnCttcbcs3Wm8PoO5Kfq6doP";
            }
        }


        public static void SetTimeout(Action AfterAction, int timeout)
        {
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = timeout;
            t.Tick += (x, y) =>
            {
                AfterAction();
                t.Stop();
                t.Dispose();
                GC.Collect();
            };
            t.Start();
        }



    }
}
