using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.LayoutService;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.IO;
using DevExpress.DataAccess.Json;
using DevExpress.Compatibility.System.Web;
using Api.Domain.Interfaces.Services.User;

namespace Api.Application.Services
{
    public class CustomReportStorageWebExtension : DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension
    {
        private DictionaryServices services;

        public CustomReportStorageWebExtension(ILayoutService layoutService, IUserService userService)
        {
            services = new DictionaryServices();
            services.Add(DictionaryServices.LAYOUT_SERVICE_KEY, layoutService);
            services.Add(DictionaryServices.USER_SERVICE_KEY, userService);
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

            if (string.IsNullOrEmpty(url))
            {
                return new byte[0];
            }

            var m_Serializer = new JavaScriptSerializer();
            var m_Filtros = m_Serializer.Deserialize<ParametrosReport>(url);

            // build report model
            var m_IReport = FactoryReport.CM_GetReport(m_Filtros, services);

            // build layout
            var m_Layout = m_IReport.CM_GetLayout();

            // build XtraReport
            XtraReport newReport = new XtraReport();
            // load layout in XtraReport
            MemoryStream streamLayout = new MemoryStream(StringParaByteArray(m_Layout));
            newReport.LoadLayout(streamLayout);

            // loadDataSource
            var m_Data = m_IReport.CM_CarregaDataSource();
            // serialize dataSource
            var jsonSerializado = m_Serializer.Serialize(m_Data);

            // build CustomJsonSource
            var json = new JsonDataSource();
            json.JsonSource = new CustomJsonSource(jsonSerializado);
            json.Name = m_Filtros.ds_data_source;
            json.Fill();

            // attach CustomJsonSource to XtraReport
            newReport.DataSource = json;

            // Return XtraReport in bytes to FrontEnd
            MemoryStream streamReport = new MemoryStream();
            newReport.SaveLayoutToXml(streamReport);
            return streamReport.ToArray();
        }

        public override Dictionary<string, string> GetUrls()
        {
            // Returns a dictionary of the existing report URLs and display names. 
            // This method is called when running the Report Designer, 
            // before the Open Report and Save Report dialogs are shown and after a new report is saved to a storage.
            var layoutService = (ILayoutService)services[DictionaryServices.LAYOUT_SERVICE_KEY];
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
            var layoutService = (ILayoutService)services[DictionaryServices.LAYOUT_SERVICE_KEY];
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
