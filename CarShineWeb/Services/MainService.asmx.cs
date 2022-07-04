using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace CarShineWeb.Services
{
    /// <summary>
    /// Summary description for MainService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class MainService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public DataSet GetDataSet(string Query, string Params = "", string token = "", string userName = "")
        {
            if (token != Properties.Settings.Default.Token) { throw new Exception("Service Authentication Error"); }
            try
            {
                var IP = HttpContext.Current.Request.UserHostAddress;
                new Thread(new ThreadStart(delegate
                {
                    try
                    {
                        File.AppendAllText("csLogs.txt", DateTime.Now.ToString() + "[]" + userName + "[]" + IP + "[]" + Query + "[]" + Params + "\r\n");
                    }
                    catch { }

                })).Start();

                //////////
                List<CarShineWeb.App_Code.Pair> P = new List<CarShineWeb.App_Code.Pair>();
                if (!string.IsNullOrEmpty(Params))
                    P = Converters.XML.DeserializeObject<List<CarShineWeb.App_Code.Pair>>(Params);
                P.Add(new CarShineWeb.App_Code.Pair("SessionUser_", userName));
                Hashtable ht = new Hashtable();
                P.ForEach(X => { ht.Add(X.Name, X.Value); });
                return DataBaseOps.GetDsBySource(Query, ht);
            }
            catch (Exception t)
            {
                /////////////
                new Thread(new ThreadStart(delegate
                {
                    try
                    {
                        File.AppendAllText("csErrorLogs.txt", DateTime.Now.ToString() + "[]" + userName + "[]" + Query + "[]" + Params + "\r\n");
                    }
                    catch { }
                })).Start();
                throw new Exception(t.Message, t);
            }
        }


    }
}
