using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShineServices
{
    public static class InfoDataBase
    {
        public static void DataSetAsync(string Query, List<Pair> Pairs = null, Action<DataSet, Exception> AfterAction = null)
        {
            wsMainService.MainService mainService = new wsMainService.MainService();
            //mainService.Url = "https://" + Properties.Settings.Default.ServiceIP + "/cs/Services/MainService.asmx";
            mainService.GetDataSetAsync(Query, Converters.XML.SerializeObject(Pairs), Properties.Settings.Default.Token, "service_");
            mainService.GetDataSetCompleted += (x, y) =>
            {
                AfterAction(y.Result, y.Error);
                mainService.Dispose();
                mainService.Disposed += (xD, yD) => { GC.Collect(); };
            };
        }

        public static void DataSetAsync(string Query, List<Pair> Pairs = null, Action<DataSet> AfterAction = null)
        {
            wsMainService.MainService mainService = new wsMainService.MainService();
            //mainService.Url = "https://" + Properties.Settings.Default.ServiceIP + "/cs/Services/MainService.asmx";
            mainService.GetDataSetAsync(Query, Converters.XML.SerializeObject(Pairs), Properties.Settings.Default.Token, "service_");
            mainService.GetDataSetCompleted += (x, y) =>
            {
                AfterAction(y.Result);
                mainService.Dispose();
                mainService.Disposed += (xD, yD) => { GC.Collect(); };
            };
        }
    }
}
