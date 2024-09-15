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
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");

            builder.Property(x => x.Id).IsRequired().HasColumnName("ID_USU");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired().HasColumnName("NOME_USU");
            builder.Property(x => x.Matricula).HasMaxLength(15).IsRequired().HasColumnName("MATR_USU");
            builder.HasIndex(x => x.Matricula).IsUnique();
            builder.Property(x => x.DataNascimento).IsRequired().HasColumnName("DATA_NASC");
            builder.Property(x => x.Email).HasMaxLength(255).IsRequired().HasColumnName("EMAIL");
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.IdTipoUsuario).IsRequired().HasColumnName("ID_TIPOUSUARIO");

            builder.HasOne(x => x.TipoUsuario).WithMany().HasForeignKey(x => x.IdTipoUsuario).IsRequired();
            builder.Navigation(x => x.TipoUsuario).AutoInclude();
        }
    }
}