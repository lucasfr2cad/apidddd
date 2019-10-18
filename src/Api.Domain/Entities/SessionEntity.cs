using System;

namespace Api.Domain.Entities
{
    public class SessionEntity : BaseEntity
    {
        public int cd_usuario { get; set; }

        public DateTime dt_data { get; set; }

        public bool st_ativo { get; set; }

        public string ds_estacao_trabalho { get; set; }

        public string ds_ip { get; set; }

        public DateTime dt_atualizacao { get; set; }

        public bool st_lembrarme { get; set; } 

        public string txt_hash { get; set; }    

        public string txt_data_login { get; set; }
    }
}
