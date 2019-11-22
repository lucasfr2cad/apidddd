using System;

namespace Api.Domain.Entities
{
    public class LayoutEntity : BaseEntity
    {
        public string ds_nome { get; set; }
        public string ds_conteudo { get; set; }
        public DateTime? dt_criacao { get; set; }
        public bool? st_padrao { get; set; }
        public string ds_nome_relatorio { get; set; }
        
    }
}
