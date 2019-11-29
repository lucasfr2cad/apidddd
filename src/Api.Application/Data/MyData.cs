using System;
using System.Data;
using Api.Domain.Interfaces.Services.User;

namespace Api.Application.Data
{
    public class MyData : DataTable
    {

        public MyData()
        {

        }

        public MyData(IUserService service)
        {
            var users = service.Get(1).Result;
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Name", typeof(String)));

            dt.Rows.Add(1, "users.ds_nome");

            // {
            // foreach (var user in users)
            // {
            //     dt.Rows.Add(user.cd_codigo, user.ds_nome);
            // }
            this.Merge(dt);
        }
        public MyData(string service)
        {
            //var users = service.Get(1).Result;
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Name", typeof(String)));
            dt.Rows.Add(1, service);
            this.Merge(dt);
        }
    }
}

