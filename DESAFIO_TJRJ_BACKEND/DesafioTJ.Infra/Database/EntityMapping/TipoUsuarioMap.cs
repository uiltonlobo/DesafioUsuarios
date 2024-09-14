using DesafioTJ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTJ.Infra.Database.EntityMapping
{
    public class TipoUsuarioMap : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.ToTable("TIPO_USUARIO");

            builder.Property(x => x.Id).IsRequired().HasColumnName("ID_TIPOUSUARIO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Origem).HasMaxLength(1).IsRequired().HasColumnName("ORIGEM");
            builder.Property(x => x.Descricao).HasMaxLength(20).IsRequired().HasColumnName("DESCR");
        }
    }
}
