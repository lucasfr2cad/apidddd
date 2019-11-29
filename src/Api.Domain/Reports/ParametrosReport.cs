namespace Api.Application.Services
{
    public class ParametrosReport
    {
        public string ds_tipo_report { get; set; }
        public int cd_report { get; set; }
        public string ds_data_source { get; set; }

        public int min_sessoes { get; set; }
    }
}