using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Api.Data.Mapping
{
    public class SessionsMap : IEntityTypeConfiguration<SessionEntity>
    {
        public void Configure(EntityTypeBuilder<SessionEntity> builder)
        {
            builder.ToTable("sessoes", schema:"base");

            builder.HasKey(s => s.cd_codigo);

            builder.Property(s => s.dt_data)
            .IsRequired()
            .HasDefaultValue(DateTime.Now);

            builder.Property(s => s.st_ativo)
            .IsRequired()
            .HasDefaultValue(true);

            builder.Property(s => s.ds_estacao_trabalho)
            .HasMaxLength(100);
            
            builder.Property(s => s.ds_ip)
            .HasMaxLength(50);

            builder.Property(s => s.dt_atualizacao)
            .HasDefaultValue(DateTime.Now);

            builder.Property(s => s.st_lembrarme)
            .HasDefaultValue(false);

            builder.Property(s => s.txt_hash)
            .HasDefaultValue("");

            builder.Property(s => s.txt_data_login)
            .HasDefaultValue("");
        }
    }
}
