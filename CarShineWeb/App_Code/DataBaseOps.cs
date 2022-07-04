using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.Web.UI.WebControls;

namespace CarShineWeb
{
    public class DataBaseOps
    {
#pragma warning disable IDE1006 // Naming Styles
        static string dBConnectionString => ConfigurationManager.ConnectionStrings["dBCarShine"].ConnectionString;
#pragma warning restore IDE1006 // Naming Styles

        public static DataSet GetDsBySource(string sel, Hashtable hT = null)
        {
            var sqlDS = new SqlDataSource
            {
                ConnectionString = dBConnectionString
            };
            sqlDS.Selecting += (object sender, SqlDataSourceSelectingEventArgs e) => e.Command.CommandTimeout = 120;
            sqlDS.SelectCommand = sel;
            if (!(hT == null))
            {
                foreach (string x in hT.Keys)
                    sqlDS.SelectParameters.Add(x, hT[x].ToString());
            }
            sqlDS.CancelSelectOnNullParameter = false;
            DataView dV = (DataView)sqlDS.Select(System.Web.UI.DataSourceSelectArguments.Empty);
            if (!(dV == null))
                return dV.Table.DataSet;
            else
                return null;
        }


    }
}