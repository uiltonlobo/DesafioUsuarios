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
    public class UsuarioSPMap : IEntityTypeConfiguration<UsuarioSP>
    {
        public void Configure(EntityTypeBuilder<UsuarioSP> builder)
        {
            builder.HasNoKey();
            builder.Property(x => x.Id).HasColumnName("ID_USU");
            builder.Property(x => x.Nome).HasColumnName("NOME_USU");
            builder.Property(x => x.Matricula).HasColumnName("MATR_USU");
            builder.Property(x => x.DataNascimento).HasColumnName("DATA_NASC");
            builder.Property(x => x.Email).HasColumnName("EMAIL");
            builder.Property(x => x.IdTipoUsuario).HasColumnName("ID_TIPOUSUARIO");
            builder.Property(x => x.Origem).HasColumnName("ORIGEM");
            builder.Property(x => x.Descricao).HasColumnName("DESCR");
        }
    }
}