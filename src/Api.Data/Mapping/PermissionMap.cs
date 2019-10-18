using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Api.Data.Mapping
{
    public class PermissionMap : IEntityTypeConfiguration<PermissionEntity>
    {
        public void Configure(EntityTypeBuilder<PermissionEntity> builder)
        {
            builder.ToTable("permissoes", schema:"base");

            builder.HasKey(p => p.cd_codigo);

            builder.Property(p => p.cd_usuario)
            .IsRequired();

            builder.Property(p => p.cd_form)
            .HasDefaultValue(0);

            builder.Property(p => p.vl_acessos)
            .IsRequired()
            .HasDefaultValue(0);
            
            builder.Property(p => p.st_adicionar)
            .IsRequired()
            .HasDefaultValue(false);

            builder.Property(p => p.st_excluir)
            .IsRequired()
            .HasDefaultValue(false);

            builder.Property(p => p.st_edita)
            .IsRequired()
            .HasDefaultValue(false);

            builder.Property(p => p.st_imprime)
            .IsRequired()
            .HasDefaultValue(false);

            builder.Property(p => p.st_menu)
            .IsRequired()
            .HasDefaultValue(false);

            builder.Property(p => p.st_favorito)
            .HasDefaultValue(false);

            builder.Property(p => p.dt_ultacesso)
            .HasDefaultValue(DateTime.Now);

            builder.Property(p => p.cd_condicao)
            .HasDefaultValue(0);
            
        }
    }
}
