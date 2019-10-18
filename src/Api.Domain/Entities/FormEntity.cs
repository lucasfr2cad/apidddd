namespace Api.Domain.Entities
{
    public class FormEntity : BaseEntity
    {
        public int cd_modulo { get; set; } 

        public string ds_arquivo { get; set; }  

        public string ds_descricao { get; set; }  

        public string ds_tags { get; set; } 

        public string txt_grid { get; set; }

        public string txt_form { get; set; }

        public int cd_grupo { get; set; }

        public int cd_icone { get; set; }

        public bool st_icone_big { get; set; }

        public string ds_icone { get; set; }

        public bool st_ativo { get; set; }

        public string cd_empresas { get; set; }
    }
}
