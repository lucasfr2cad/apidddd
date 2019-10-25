namespace Api.Domain.Entities
{
    public class ConfigEntity
    {
        public string campo { get; set; } 

        public string modulo { get; set; } 

        public string descricao { get; set; }

        public bool edicao { get; set; }

        public decimal valor { get; set; }

        public int cd_empresa { get; set; }   
    }
}
