using System;
using System.Data;

namespace Api.Application.Data
{
    public class MyData
    {

        public static DataTable GetData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Name", typeof(String)));
            dt.Rows.Add(1, "Lucas");
            dt.Rows.Add(2, "Fogaça");
            return dt;
        }
    }
}