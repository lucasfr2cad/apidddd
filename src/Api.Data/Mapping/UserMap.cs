using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("usuarios", schema:"base");

            builder.HasKey(u => u.cd_codigo);

            builder.Property(u => u.ds_nome)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(u => u.st_admin)
            .IsRequired()
            .HasDefaultValue(false);

            builder.Property(u => u.ds_senha)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(u => u.dt_ultacesso);

            builder.Property(u => u.ds_ultcomp)
            .HasMaxLength(30);

            builder.Property(u => u.cd_compromisso)
            .HasDefaultValue(0);

            builder.Property(u => u.cd_cliente)
            .HasDefaultValue(0);

            builder.Property(u => u.cd_vendedor)
            .HasDefaultValue(0);

            builder.Property(u => u.vl_max_sessoes)
            .HasDefaultValue(1);

            builder.Property(u => u.vl_max_sessoes)
            .HasDefaultValue(1);

            builder.Property(u => u.ds_settings)
            .HasDefaultValue("");

            builder.Property(u => u.cd_reiniciar_modo)
            .HasDefaultValue(0);

            builder.Property(u => u.ds_apelido)
            .HasMaxLength(20);

            builder.Property(u => u.st_excluido)
            .HasDefaultValue(false);

            builder.Property(u => u.cd_empresa)
            .HasDefaultValue(1);

        }
    }
}
