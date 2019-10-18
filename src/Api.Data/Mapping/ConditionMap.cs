using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Api.Data.Mapping
{
    public class ConditionMap : IEntityTypeConfiguration<ConditionEntity>
    {
        public void Configure(EntityTypeBuilder<ConditionEntity> builder)
        {
            builder.ToTable("condicoes", schema:"base");

            builder.HasKey(c => c.cd_codigo);

            builder.Property(c => c.ds_condicao)
            .HasMaxLength(60)
            .HasDefaultValue("");

            builder.Property(c => c.ds_descricao)
            .HasMaxLength(250)
            .HasDefaultValue("");

            builder.Property(c => c.ds_msg_erro)
            .HasMaxLength(250)
            .HasDefaultValue("");
        }
    }
}
