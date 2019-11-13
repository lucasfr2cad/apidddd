using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public partial class ClientMap : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.ToTable("clientes", schema: "public");

            builder.HasKey(e => e.cd_codigo)
                .HasName("idx_cd_cliente");

            builder.HasIndex(e => e.CdCodfis)
                .HasName("idx_cli_codfis");

            builder.HasIndex(e => e.CdPortador)
                .HasName("idx_cli_portado");

            builder.HasIndex(e => e.CdRota)
                .HasName("idx_cli_rota");

            builder.HasIndex(e => e.CdVendedor)
                .HasName("idx_cli_vendedo");

            builder.HasIndex(e => e.DsNome)
                .HasName("idx_cli_nome");

            builder.HasIndex(e => e.Responsavel)
                .HasName("idx_cli_resp");

            builder.Property(e => e.cd_codigo)
                .HasColumnName("cd_codigo")
                .HasComment("-1;Codigo");

            builder.Property(e => e.CdClasse)
                .HasColumnName("cd_classe")
                .HasComment("99;Classes;clacli;cd_clacli;ds_clacli");

            builder.Property(e => e.CdCodfis)
                .HasColumnName("cd_codfis")
                .HasDefaultValueSql("0")
                .HasComment("99;Codfis;codfis;cd_codfis;ds_codfis");

            builder.Property(e => e.CdCond)
                .HasColumnName("cd_cond")
                .HasDefaultValueSql("0");

            builder.Property(e => e.CdContabil)
                .HasColumnName("cd_contabil")
                .HasDefaultValueSql("0");

            builder.Property(e => e.CdCrt)
                .HasColumnName("cd_crt")
                .HasDefaultValueSql("3");

            builder.Property(e => e.CdEstado1)
                .HasColumnName("cd_estado1")
                .HasMaxLength(2)
                .HasComment("99;Estado");

            builder.Property(e => e.CdEstado2)
                .HasColumnName("cd_estado2")
                .HasMaxLength(2)
                .HasComment(@"99;Estado2");

            builder.Property(e => e.CdOperacao).HasColumnName("cd_operacao");

            builder.Property(e => e.CdPais)
                .HasColumnName("cd_pais")
                .HasDefaultValueSql("1058");

            builder.Property(e => e.CdPisCofins)
                .HasColumnName("cd_pis_cofins")
                .HasDefaultValueSql("0");

            builder.Property(e => e.CdPortador)
                .HasColumnName("cd_portador")
                .HasDefaultValueSql("0");

            builder.Property(e => e.CdPrazo)
                .HasColumnName("cd_prazo")
                .HasComment("99;Prazo");

            builder.Property(e => e.CdRamo).HasColumnName("cd_ramo");

            builder.Property(e => e.CdRota)
                .HasColumnName("cd_rota")
                .HasDefaultValueSql("1")
                .HasComment("05;Rota;rotas;cd_codigo;cd_codigo");

            builder.Property(e => e.CdTabpreco)
                .HasColumnName("cd_tabpreco")
                .HasDefaultValueSql("0")
                .HasComment("1;Tabpreco;v_tabs_precos;cd_codigo;ds_nome");

            builder.Property(e => e.CdTabprecoFrete)
                .HasColumnName("cd_tabpreco_frete")
                .HasDefaultValueSql("0");

            builder.Property(e => e.CdTipoFrete)
                .HasColumnName("cd_tipo_frete")
                .HasDefaultValueSql("1");

            builder.Property(e => e.CdTpdoc)
                .HasColumnName("cd_tpdoc")
                .HasDefaultValueSql("0");

            builder.Property(e => e.CdTributa)
                .HasColumnName("cd_tributa")
                .HasDefaultValueSql("0");

            builder.Property(e => e.CdUsuario).HasColumnName("cd_usuario");

            builder.Property(e => e.CdVendedor)
                .HasColumnName("cd_vendedor")
                .HasDefaultValueSql("0")
                .HasComment("20;Vendedor;vendedores;cd_codigo;ds_nome");

            builder.Property(e => e.CdVendedor2)
                .HasColumnName("cd_vendedor2")
                .HasDefaultValueSql("0")
                .HasComment("99;Vendint;v_vendedores;cd_codigo;ds_nome");

            builder.Property(e => e.CdVersao).HasColumnName("cd_versao");

            builder.Property(e => e.DsBairro1)
                .IsRequired()
                .HasColumnName("ds_bairro1")
                .HasMaxLength(30)
                .HasDefaultValueSql("''::character varying")
                .HasComment("99;Bairro");

            builder.Property(e => e.DsBairro2)
                .IsRequired()
                .HasColumnName("ds_bairro2")
                .HasMaxLength(30)
                .HasDefaultValueSql("''::character varying")
                .HasComment("99;Bairro2");

            builder.Property(e => e.DsCep1)
                .HasColumnName("ds_cep1")
                .HasMaxLength(10)
                .HasComment("99;Cep");

            builder.Property(e => e.DsCep2)
                .HasColumnName("ds_cep2")
                .HasMaxLength(10)
                .HasComment("99;Cep2");

            builder.Property(e => e.DsCfop)
                .HasColumnName("ds_cfop")
                .HasMaxLength(10)
                .HasDefaultValueSql("''::character varying");

            builder.Property(e => e.DsCidade1)
                .HasColumnName("ds_cidade1")
                .HasMaxLength(30)
                .HasComment("04;Cidade");

            builder.Property(e => e.DsCidade2)
                .HasColumnName("ds_cidade2")
                .HasMaxLength(30)
                .HasComment("99;Cidade2");

            builder.Property(e => e.DsCnae)
                .HasColumnName("ds_cnae")
                .HasMaxLength(20)
                .IsFixedLength()
                .HasDefaultValueSql("''::bpchar")
                .HasComment("99;CNAE");

            builder.Property(e => e.DsCnpj)
                .HasColumnName("ds_cnpj")
                .HasMaxLength(20)
                .HasComment("50;Cnpj");

            builder.Property(e => e.DsComple1)
                .IsRequired()
                .HasColumnName("ds_comple1")
                .HasMaxLength(70)
                .HasDefaultValueSql("''::character varying");

            builder.Property(e => e.DsComple2)
                .IsRequired()
                .HasColumnName("ds_comple2")
                .HasMaxLength(70)
                .HasDefaultValueSql("''::character varying");

            builder.Property(e => e.DsContato1)
                .HasColumnName("ds_contato1")
                .HasMaxLength(20)
                .HasComment("99;Contato1");

            builder.Property(e => e.DsContato2)
                .HasColumnName("ds_contato2")
                .HasMaxLength(20)
                .HasComment("99;Contato2");

            builder.Property(e => e.DsContato3)
                .HasColumnName("ds_contato3")
                .HasMaxLength(20)
                .HasComment("99;Contato3");

            builder.Property(e => e.DsCpf)
                .HasColumnName("ds_cpf")
                .HasMaxLength(14)
                .HasComment("99;Cpf");

            builder.Property(e => e.DsEmail)
                .HasColumnName("ds_email")
                .HasMaxLength(100)
                .IsFixedLength()
                .HasDefaultValueSql("''::bpchar")
                .HasComment("99;Email");

            builder.Property(e => e.DsEndereco1)
                .HasColumnName("ds_endereco1")
                .HasMaxLength(50)
                .HasComment("06;Endereco");

            builder.Property(e => e.DsEndereco2)
                .HasColumnName("ds_endereco2")
                .HasMaxLength(50)
                .HasComment("99;Endereco2");

            builder.Property(e => e.DsFantasia)
                .HasColumnName("ds_fantasia")
                .HasMaxLength(60)
                .HasComment("02;Fantasia");

            builder.Property(e => e.DsFone1)
                .HasColumnName("ds_fone1")
                .HasMaxLength(15)
                .HasComment("07;Fone");

            builder.Property(e => e.DsFone2)
                .HasColumnName("ds_fone2")
                .HasMaxLength(15)
                .HasComment("99;Fone2");

            builder.Property(e => e.DsFone3)
                .HasColumnName("ds_fone3")
                .HasMaxLength(15)
                .HasComment("99;Fone3");

            builder.Property(e => e.DsIes)
                .HasColumnName("ds_ies")
                .HasMaxLength(18)
                .HasComment("99;Ies");

            builder.Property(e => e.DsIm)
                .HasColumnName("ds_im")
                .HasMaxLength(15)
                .HasDefaultValueSql("''::character varying");

            builder.Property(e => e.DsIndicou)
                .HasColumnName("ds_indicou")
                .HasMaxLength(30)
                .HasComment("99;ds_indicou");

            builder.Property(e => e.DsLogo)
                .HasColumnName("ds_logo")
                .HasMaxLength(100)
                .HasDefaultValueSql("''::character varying");

            builder.Property(e => e.DsMsgFiscal)
                .HasColumnName("ds_msg_fiscal")
                .HasDefaultValueSql("''::text");

            builder.Property(e => e.DsNome)
                .HasColumnName("ds_nome")
                .HasMaxLength(60)
                .HasComment("01;Nome");

            builder.Property(e => e.DsNumero1)
                .HasColumnName("ds_numero1")
                .HasMaxLength(10)
                .HasDefaultValueSql("''::character varying");

            builder.Property(e => e.DsNumero2)
                .HasColumnName("ds_numero2")
                .HasMaxLength(10)
                .HasDefaultValueSql("''::character varying");

            builder.Property(e => e.DsObsFat)
                .HasColumnName("ds_obs_fat")
                .HasDefaultValueSql("''::text");

            builder.Property(e => e.DsRg)
                .HasColumnName("ds_rg")
                .HasMaxLength(12)
                .HasComment("99;Rg");

            builder.Property(e => e.DsSenha)
                .HasColumnName("ds_senha")
                .HasMaxLength(20)
                .HasDefaultValueSql("'segredo'::character varying")
                .HasComment("99;Senha");

            builder.Property(e => e.DsSetor1)
                .HasColumnName("ds_setor1")
                .HasMaxLength(10)
                .HasComment("99;Setor1");

            builder.Property(e => e.DsSetor2)
                .HasColumnName("ds_setor2")
                .HasMaxLength(10)
                .HasComment("99;Setor2");

            builder.Property(e => e.DsSetor3)
                .HasColumnName("ds_setor3")
                .HasMaxLength(10)
                .HasComment("99;Setor3");

            builder.Property(e => e.DsSite)
                .HasColumnName("ds_site")
                .HasMaxLength(50)
                .HasDefaultValueSql("''::bpchar");

            builder.Property(e => e.DsSuframa)
                .HasColumnName("ds_suframa")
                .HasMaxLength(9)
                .HasDefaultValueSql("''::character varying");

            builder.Property(e => e.DsTipo)
                .HasColumnName("ds_tipo")
                .HasMaxLength(1)
                .HasComment("99;Tipo");

            builder.Property(e => e.DtAtual)
                .HasColumnName("dt_atual")
                .HasColumnType("date");

            builder.Property(e => e.DtCadastro)
                .HasColumnName("dt_cadastro")
                .HasColumnType("date")
                .HasDefaultValueSql("('now'::text)::date")
                .HasComment("99;Dtcad");

            builder.Property(e => e.DtConsultaCredito)
                .HasColumnName("dt_consulta_credito")
                .HasColumnType("date");

            builder.Property(e => e.DtNascimento)
                .HasColumnName("dt_nascimento")
                .HasColumnType("date")
                .HasComment("99;Dtnascim");

            builder.Property(e => e.DtPagou)
                .HasColumnName("dt_pagou")
                .HasColumnType("date")
                .HasComment("99;dt_pagou");

            builder.Property(e => e.DtUltima)
                .HasColumnName("dt_ultima")
                .HasColumnType("date")
                .HasComment("99;Dtultima");

            builder.Property(e => e.LogPercSt)
                .HasColumnName("log_perc_st")
                .HasDefaultValueSql("false");

            builder.Property(e => e.Net).HasColumnName("net");

            builder.Property(e => e.Obs)
                .HasColumnName("obs")
                .HasMaxLength(300)
                .HasComment("99;Obs");

            builder.Property(e => e.Responsavel)
                .HasColumnName("responsavel")
                .HasComment("50;Respons;v_clientes;cd_codigo;ds_nome");

            builder.Property(e => e.StAssinatura)
                .HasColumnName("st_assinatura")
                .HasDefaultValueSql("false");

            builder.Property(e => e.StCliente)
                .HasColumnName("st_cliente")
                .HasDefaultValueSql("true");

            builder.Property(e => e.StExportador)
                .HasColumnName("st_exportador")
                .HasDefaultValueSql("false");

            builder.Property(e => e.StFeedback)
                .HasColumnName("st_feedback")
                .HasDefaultValueSql("false");

            builder.Property(e => e.StFornece)
                .HasColumnName("st_fornece")
                .HasDefaultValueSql("false");

            builder.Property(e => e.TipoCliente).HasColumnName("tipo_cliente");

            builder.Property(e => e.TipoEmpresa)
                .HasColumnName("tipo_empresa")
                .HasDefaultValueSql("1");

            builder.Property(e => e.VlComissao)
                .HasColumnName("vl_comissao")
                .HasColumnType("numeric(4,2)")
                .HasDefaultValueSql("0")
                .HasComment("99;Comissao");

            builder.Property(e => e.VlDescmax)
                .HasColumnName("vl_descmax")
                .HasColumnType("numeric(10,2)")
                .HasDefaultValueSql("0");

            builder.Property(e => e.VlDescontos)
                .HasColumnName("vl_descontos")
                .HasColumnType("numeric(20,2)")
                .HasComment("99;vl_descon");

            builder.Property(e => e.VlDescper)
                .HasColumnName("vl_descper")
                .HasColumnType("numeric(10,2)")
                .HasDefaultValueSql("0")
                .HasComment("99;vldescper");

            builder.Property(e => e.VlDescper02)
                .HasColumnName("vl_descper02")
                .HasColumnType("numeric(10,2)")
                .HasDefaultValueSql("0.00");

            builder.Property(e => e.VlDescper101)
                .HasColumnName("vl_descper101")
                .HasColumnType("numeric(10,2)")
                .HasDefaultValueSql("0.00");

            builder.Property(e => e.VlDescper102)
                .HasColumnName("vl_descper102")
                .HasColumnType("numeric(10,2)")
                .HasDefaultValueSql("0.00");

            builder.Property(e => e.VlDescper12)
                .HasColumnName("vl_descper12")
                .HasColumnType("numeric(10,2)")
                .HasDefaultValueSql("0");

            builder.Property(e => e.VlDescper18)
                .HasColumnName("vl_descper18")
                .HasColumnType("numeric(10,2)")
                .HasDefaultValueSql("0.00");

            builder.Property(e => e.VlDescper2)
                .HasColumnName("vl_descper2")
                .HasColumnType("numeric(10,2)")
                .HasDefaultValueSql("0")
                .HasComment("99;vldescper2");

            builder.Property(e => e.VlJuros)
                .HasColumnName("vl_juros")
                .HasColumnType("numeric(20,2)")
                .HasDefaultValueSql("0")
                .HasComment("99;vl_juros");

            builder.Property(e => e.VlLimite)
                .HasColumnName("vl_limite")
                .HasColumnType("numeric(20,2)")
                .HasComment("99;vl_limite");

            builder.Property(e => e.VlMediaDiasPg)
                .HasColumnName("vl_media_dias_pg")
                .HasDefaultValueSql("0");

            builder.Property(e => e.VlRecebi)
                .HasColumnName("vl_recebi")
                .HasColumnType("numeric(20,2)")
                .HasDefaultValueSql("0")
                .HasComment("99;vl_recebi");

            builder.Property(e => e.VlTotal)
                .HasColumnName("vl_total")
                .HasColumnType("numeric(20,2)")
                .HasDefaultValueSql("0")
                .HasComment("99;vl_total");
        }
    }
}
