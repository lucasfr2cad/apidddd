using Api.Application.Reports;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.LayoutService;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using DevExpress.DataAccess.ObjectBinding;
using Api.Application.Data;
using Api.Domain.Interfaces.Services.User;
using Api.Data.Implementations;
using Api.Data.Repository;
using DevExpress.DataAccess.Json;
using DevExpress.Compatibility.System.Web;
using Microsoft.EntityFrameworkCore;
using Api.Data.Context;
using System.Linq;

namespace Api.Application.Services
{

    public class ParametrosReport
    { 
        public string ds_tipo_report { get; set; }
        public int cd_report { get; set; }
       public string ds_nome { get; set; }

        public int min_sessoes { get; set; }
    }

    public static class FactoryReport 
    { 
        public static IReport CM_GetReport(ParametrosReport p_ParametroReport, ILayoutService layoutService)
        {
            switch (p_ParametroReport.ds_tipo_report)
            {
                case "pView":
                    return new ProdutosReport(p_ParametroReport, layoutService);
                case "dView":
                    return new UserReport(p_ParametroReport, layoutService);
            }

            throw new ApplicationException("Report não encontrado.");
        }
    }


    public class UserReport : IReport
    {
        public UserReport(ParametrosReport p_ParametrosReport, ILayoutService p_LayoutService) : base(p_ParametrosReport, p_LayoutService)
        {
        }

        public override object CM_CarregaDataSource()
        {
            var  options = new DbContextOptionsBuilder<MyContext>().UseNpgsql("Host=10.0.0.10;Port=5432;Database=gcad;User Id=rei;Password=teste;").Options;
            var context = new MyContext(options);
            var baseRepository = new BaseRepository<UserEntity>(context);

            var m_DataSource = baseRepository._dataset.Where(a => a.ds_nome.Contains(C_ParametrosReport.ds_nome)).ToList();

            var m_ListaUserDetail = new List<UserDetailDTO>();

            foreach (var m_Registro in m_DataSource)
                m_ListaUserDetail.Add(new UserDetailDTO()
                {
                    C_Codigo = m_Registro.cd_codigo,
                    C_Nome = m_Registro.ds_nome
                });

            var m_Retorno = new UserDTO()
            {
                C_DataReport = DateTime.Now,
                C_NomeReport = "Majin Buu",
                C_ListaUsers = m_ListaUserDetail
            };

            return m_Retorno;
        }

    }

    public abstract class IReport
    {
        public ParametrosReport C_ParametrosReport { get; set; }
        public ILayoutService C_LayoutService { get; set; }

        public IReport(ParametrosReport p_ParametrosReport, ILayoutService p_LayoutService)
        {
            C_ParametrosReport = p_ParametrosReport;
            C_LayoutService = p_LayoutService;
        }

        public abstract object CM_CarregaDataSource();

        public string CM_GetLayout()
        {
            var layoutFinded = C_LayoutService.Get(C_ParametrosReport.cd_report);
            return layoutFinded.Result.ds_conteudo;
        }
    }



    public class ReportStorageWebExtension1 : DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension
    {
        private ILayoutService layoutService;

        public ReportStorageWebExtension1(ILayoutService service)
        {
            layoutService = service;
        }

        public override bool CanSetData(string url)
        {
            // Determines whether or not it is possible to store a report by a given URL. 
            // For instance, make the CanSetData method return false for reports that should be read-only in your storage. 
            // This method is called only for valid URLs (i.e., if the IsValidUrl method returned true) before the SetData method is called.

            return true;
        }

        public override bool IsValidUrl(string url)
        {
            // Determines whether or not the URL passed to the current Report Storage is valid. 
            // For instance, implement your own logic to prohibit URLs that contain white spaces or some other special characters. 
            // This method is called before the CanSetData and GetData methods.

            return true;
        }

        public override byte[] GetData(string url)
        {
            var m_Filtros = new ParametrosReport() { ds_tipo_report = "dView", cd_report = 7, ds_nome = "reitech" };
            var m_Serializer = new JavaScriptSerializer();
            //var m_Filtros = m_Serializer.Deserialize<filtros>(p_Filtros);

            var m_IReport = FactoryReport.CM_GetReport(m_Filtros, layoutService);

            var m_Layout = m_IReport.CM_GetLayout();

            XtraReport newReport = new XtraReport();
           
            MemoryStream streamLayout = new MemoryStream(StringParaByteArray(m_Layout));
            newReport.LoadLayout(streamLayout);

            var m_Data = m_IReport.CM_CarregaDataSource();

            var jsonSerializado = m_Serializer.Serialize(m_Data);
            var json = new JsonDataSource();

            json.JsonSource = new CustomJsonSource(jsonSerializado);
            json.Name = m_Filtros.ds_tipo_report;
            json.Fill();

            newReport.DataSource = json;

            MemoryStream streamReport = new MemoryStream();
            newReport.SaveLayoutToXml(streamReport);

            return streamReport.ToArray();
        }

        public override Dictionary<string, string> GetUrls()
        {
            // Returns a dictionary of the existing report URLs and display names. 
            // This method is called when running the Report Designer, 
            // before the Open Report and Save Report dialogs are shown and after a new report is saved to a storage.

            var reports = layoutService.GetAll().Result;
            var dicionario = new Dictionary<string, string>();
            foreach (var report in reports)
            {
                dicionario.Add(report.cd_codigo.ToString(), report.ds_nome);
            }
            return dicionario;
        }

        public override void SetData(XtraReport report, string url)
        {
            // Stores the specified report to a Report Storage using the specified URL. 
            // This method is called only after the IsValidUrl and CanSetData methods are called.
            var Layout = new LayoutEntity();
            MemoryStream output = new MemoryStream();
            report.SaveLayoutToXml(output);
            Layout.ds_conteudo = ByteArrayParaString(output.ToArray());

            int idConvertido;
            if (Int32.TryParse(url, out idConvertido))
            {
                Layout.cd_codigo = idConvertido;
                layoutService.Update(Layout);
            }
            else
            {
                Layout.ds_nome = url;
                layoutService.Insert(Layout);
            }
        }

        public static String ByteArrayParaString(byte[] str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetString(str);
        }

        public static byte[] StringParaByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }

        public override string SetNewData(XtraReport report, string defaultUrl)
        {
            // Stores the specified report using a new URL. 
            // The IsValidUrl and CanSetData methods are never called before this method. 
            // You can validate and correct the specified URL directly in the SetNewData method implementation 
            // and return the resulting URL used to save a report in your storage.

            SetData(report, defaultUrl);
            return defaultUrl;
        }
    }
}
