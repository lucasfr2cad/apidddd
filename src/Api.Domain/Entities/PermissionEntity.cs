using System;

namespace Api.Domain.Entities
{
    public class PermissionEntity : BaseEntity
    {
        
        public int cd_usuario { get; set; } 

        public int cd_form { get; set; }

        public int vl_acessos { get; set; }

        public bool st_adicionar { get; set; }

        public bool st_excluir { get; set; }

        public bool st_edita { get; set; }

        public bool st_imprime { get; set; }    

        public bool st_menu { get; set; }

        public bool st_favorito { get; set; }   

        public DateTime? dt_ultacesso { get; set; }

        public int cd_condicao { get; set; }
        
    }
}
