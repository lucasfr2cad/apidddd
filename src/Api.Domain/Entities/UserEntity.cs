using System;

namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string ds_nome { get; set; }

        public string ds_senha { get; set; }

        public bool st_admin { get; set; }

        public DateTime? dt_ultacesso { get; set; }

        public string ds_ultcomp { get; set; }

        public int? cd_compromisso { get; set; }

        public int? cd_cliente { get; set; }

        public int? cd_vendedor  { get; set; }

        public int? vl_max_sessoes { get; set; }

        public string ds_settings { get; set; }

        public int? cd_reiniciar_modo { get; set; }

        public string ds_apelido { get; set; }

        public bool st_excluido { get; set; }

        public int? cd_empresa { get; set; } 
    }
}
