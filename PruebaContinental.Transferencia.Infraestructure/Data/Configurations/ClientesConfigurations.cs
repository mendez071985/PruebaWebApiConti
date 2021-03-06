using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaContinental.Transferencia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Transferencia.Infraestructure.Data.Configurations
{
    public class ClientesConfigurations : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.HasKey(e => new { e.Id, e.Codigo })
             .HasName("PK__Cliente__561C721FCC932B0C");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Codigo)
                .HasColumnName("codigo")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Apellido)
                .HasColumnName("apellido")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Direccion)
                .HasColumnName("direccion ")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasMaxLength(2)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Telefono)
                .HasColumnName("telefono")
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}
