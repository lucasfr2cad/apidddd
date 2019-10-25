using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ConfigMap : IEntityTypeConfiguration<ConfigEntity>
    {
        public void Configure(EntityTypeBuilder<ConfigEntity> builder)
        {
            builder.ToTable("config", schema:"public");

            builder.HasKey(c => new { c.campo, c.cd_empresa});

            builder.Property(c => c.modulo)
            .HasDefaultValue("")
            .HasMaxLength(10);

            builder.Property(c => c.descricao)
            .HasDefaultValue("")
            .HasMaxLength(255);

            builder.Property(c => c.edicao)
            .HasDefaultValue(false);

            builder.Property(c => c.valor)
            .HasDefaultValue(0);

            builder.Property(c => c.cd_empresa)
            .IsRequired()
            .HasDefaultValue(0);
        }
    }
}
