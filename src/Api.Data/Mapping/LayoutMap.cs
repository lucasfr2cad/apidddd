using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class LayoutMap : IEntityTypeConfiguration<LayoutEntity>
    {
        public void Configure(EntityTypeBuilder<LayoutEntity> entity)
        {
                entity.ToTable("leiaute_relatorios", schema:"base");


                entity.HasKey(e => e.cd_codigo)
                .HasName("base_leiaute_relatorios_pkey");

                entity.Property(e => e.ds_nome)
                .HasMaxLength(100);

                entity.Property(e => e.ds_nome_relatorio)
                .HasMaxLength(250);

                entity.Property(e => e.ds_conteudo);

                entity.Property(e => e.st_padrao);

                

        }
    }
}
