using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Api.Data.Mapping
{
    public class FormMap : IEntityTypeConfiguration<FormEntity>
    {
        public void Configure(EntityTypeBuilder<FormEntity> builder)
        {
            builder.ToTable("formularios", schema:"base");

             builder.HasKey(f => f.cd_codigo);

             builder.Property(f => f.cd_modulo)
             .IsRequired()
             .HasDefaultValue(0);

             builder.Property(f => f.ds_arquivo)
             .IsRequired()
             .HasMaxLength(100);

             builder.Property(f => f.ds_tags)
             .IsRequired()
             .HasMaxLength(100)
             .HasDefaultValue("");

             builder.Property(f => f.txt_grid)
             .HasDefaultValue("");

             builder.Property(f => f.txt_form)
             .HasDefaultValue("");

             builder.Property(f => f.cd_grupo)
             .HasDefaultValue(0);

             builder.Property(f => f.cd_icone)
             .HasDefaultValue(0);

             builder.Property(f => f.ds_icone)
             .HasMaxLength(100)
             .HasDefaultValue("");

             builder.Property(f => f.st_icone_big)
             .HasDefaultValue(false);

             builder.Property(f => f.st_ativo)
             .HasDefaultValue(true);


        }
    }
}
