using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ReceiveMap : IEntityTypeConfiguration<ReceiveEntity>
    {
        public void Configure(EntityTypeBuilder<ReceiveEntity> entity)
        {
                entity.ToTable("receber", schema:"public");

                entity.HasKey(e => e.cd_codigo)
                    .HasName("cd_codigo014");

                entity.HasIndex(e => e.cd_cliente)
                    .HasName("cd_cliente006");

                entity.HasIndex(e => e.cd_nota)
                    .HasName("fki_receber_cd_nota_fkey");

                entity.HasIndex(e => e.cd_portador)
                    .HasName("cd_portado004");

                entity.HasIndex(e => e.cd_vendedor)
                    .HasName("cd_vendedo002");

                entity.HasIndex(e => e.ds_docto)
                    .HasName("ds_docto002");

                entity.HasIndex(e => e.ds_pedido)
                    .HasName("ds_pedido");

                entity.HasIndex(e => e.ds_romaneio)
                    .HasName("ds_romanei");

                entity.HasIndex(e => e.dt_vencimento)
                    .HasName("dt_vencime001");

                entity.HasIndex(e => e.situacao)
                    .HasName("idx_receber_situacao")
                    .HasFilter("(situacao > (-1))");

                entity.HasIndex(e => e.vl_pago)
                    .HasName("idx_receber_vl_pago");

                entity.Property(e => e.cd_codigo).HasComment("-1");

                entity.Property(e => e.boleto_token).HasMaxLength(100);

                entity.Property(e => e.cd_acaocob)
                    .HasMaxLength(2)
                    .IsFixedLength()
                    .HasDefaultValueSql("'01'::bpchar");

                entity.Property(e => e.cd_avalista).HasDefaultValueSql("0");

                entity.Property(e => e.cd_bordero)
                    .HasDefaultValueSql("0")
                    .HasComment("09;Bordero");

                entity.Property(e => e.cd_cliente).HasComment("03;Client_res;Clientes;cd_codigo;ds_nome");

                entity.Property(e => e.cd_cliente2)
                    .HasDefaultValueSql("0")
                    .HasComment("04;Client_fin;v_Clientes;cd_codigo;ds_nome");

                entity.Property(e => e.cd_empresa)
                    .HasDefaultValueSql("1")
                    .HasComment("08;Empresa");

                entity.Property(e => e.cd_equifax)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.cd_fecha).HasDefaultValueSql("0");

                entity.Property(e => e.cd_tipo_baixa).HasDefaultValueSql("0");

                entity.Property(e => e.cobrado).HasDefaultValueSql("false");

                entity.Property(e => e.ds_docto)
                    .HasMaxLength(15)
                    .HasComment("01;Docto");

                entity.Property(e => e.ds_notafis)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.ds_numero)
                    .HasMaxLength(25)
                    .IsFixedLength()
                    .HasDefaultValueSql("''::bpchar")
                    .HasComment("99");

                entity.Property(e => e.ds_pedido).HasMaxLength(15);

                entity.Property(e => e.ds_romaneio)
                    .HasMaxLength(15)
                    .HasComment("09;Romaneio");

                entity.Property(e => e.ds_serie)
                    .HasMaxLength(5)
                    .HasComment("02;Serie");

                entity.Property(e => e.ds_tipodoc)
                    .HasMaxLength(3)
                    .IsFixedLength()
                    .HasDefaultValueSql("''::bpchar");

                entity.Property(e => e.dt_compensa).HasColumnType("date");

                entity.Property(e => e.dt_emissao)
                    .HasColumnType("date")
                    .HasDefaultValueSql("('now'::text)::date")
                    .HasComment("05;Emissao");

                entity.Property(e => e.dt_limite).HasColumnType("date");

                entity.Property(e => e.dt_pagto)
                    .HasColumnType("date")
                    .HasComment("99;DtPagto");

                entity.Property(e => e.dt_remessa).HasColumnType("date");

                entity.Property(e => e.dt_vencimento)
                    .HasColumnType("date")
                    .HasComment("06;Venc");

                entity.Property(e => e.nro_remessa).HasDefaultValueSql("0");

                entity.Property(e => e.obs)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.situacao).HasDefaultValueSql("0");

                entity.Property(e => e.st_cancela).HasDefaultValueSql("false");

                entity.Property(e => e.st_exportado).HasDefaultValueSql("false");

                entity.Property(e => e.tp_pagto)
                    .HasMaxLength(3)
                    .IsFixedLength()
                    .HasDefaultValueSql("''::bpchar");

                entity.Property(e => e.vl_desconto)
                    .HasColumnType("numeric(9,2)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.vl_descpag)
                    .HasColumnType("numeric(19,2)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.vl_imposto)
                    .HasColumnType("numeric(10,2)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.vl_juros)
                    .HasColumnType("numeric(9,2)")
                    .HasDefaultValueSql("3");

                entity.Property(e => e.vl_jurospag)
                    .HasColumnType("numeric(19,2)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.vl_multa)
                    .HasColumnType("numeric(19,2)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.vl_pago)
                    .HasColumnType("numeric(19,2)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.vl_protesto).HasDefaultValueSql("0");

                entity.Property(e => e.vl_valor)
                    .HasColumnType("numeric(19,2)")
                    .HasComment("07;Valor");
        }
    }
}
