using System;
using System.Data;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Data
{
    public class MyData
    {

            static DbContextOptions<MyContext> options = new DbContextOptionsBuilder<MyContext>().UseNpgsql("Host=10.0.0.10;Port=5432;Database=gcad;User Id=rei;Password=teste;").Options;
            static MyContext context = new MyContext(options);
            static BaseRepository<UserEntity> baseRepository = new BaseRepository<UserEntity>(context);

            static DataTable dt = null;
        //public static async Task<DataTable> GetData()
        public static DataTable GetData()
        {

            if(dt == null){
                dt = new DataTable();
            }else{
                return dt;
            }
             
            dt.Columns.Add(new DataColumn("ID", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Name", typeof(String)));

            //var users = await baseRepository.SelectAsync();
            var users = baseRepository.SelectAsync().Result;

            
            // for (int i = 0; i < 3; i++)
            // {
            //     dt.Rows.Add(users[i].cd_codigo, users[i].ds_nome);
            // }
            foreach (var user in users)
            {
                dt.Rows.Add(user.cd_codigo, user.ds_nome);
            }

            return dt;
        }
    }
}