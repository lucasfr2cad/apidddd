using System;

namespace Api.Domain.Entities
{
    public class ReceiveEntity: BaseEntity
    {

        public string ds_doct { get; set; }

        public string ds_serie { get; set; }

        public DateTime dt_emissao { get; set; }

        public string ds_notafis { get; set; }

        public int? cd_cliente { get; set; }

        public int? cd_contabil { get; set; }

        public int? cd_portador { get; set; }  

        public string ds_pedido { get; set; }

        public string ds_romaneio { get; set; }

        public DateTime dt_vencimento { get; set; }

        public decimal?  vl_valor { get; set; }

        public decimal? vl_desconto { get; set; }

        public DateTime? dt_limite { get; set; }

        public decimal? vl_multa { get; set; }

        public decimal? vl_juros { get; set; }

        public DateTime? dt_pagto { get; set; }

        public decimal? vl_pago { get; set; }

        public decimal? vl_jurospag { get; set; }

        public decimal? vl_descpag { get; set; }

        public string obs { get; set; }

        public int cd_empresa { get; set; }

        public bool cobrado { get; set; }

        public DateTime dt_remessa { get; set; }

        public int nro_remessa { get; set; }

        public int cd_fecha { get; set; }

        public string ds_tipodoc { get; set; }

        public int cd_bordero { get; set; }

        public DateTime dt_compensa { get; set; }

        public int cd_cliente2 { get; set; }

        public decimal vl_imposto { get; set; }

        public string ds_numero { get; set; }

        public bool st_cancela { get; set; }

        public string tp_pagto { get; set; }

        public int? situacao { get; set; }

        public string cd_equifax { get; set; }

        public string cd_tipo_baixa { get; set; }

        public string cd_acaocob { get; set; }

        public int vl_protesto { get; set; }

        public int? cd_parcela { get; set; }

        public int? cd_parcela_seq { get; set; }  

        public bool st_exportado { get; set; }  

        public int? cd_nota { get; set; }   

        public int cd_avalista { get; set; }

        public string boleto_html { get; set; }

        public string boleto_token { get; set; }
        
    }
}
