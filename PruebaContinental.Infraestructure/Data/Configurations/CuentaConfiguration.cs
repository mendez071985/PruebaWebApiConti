using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaContinental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Infraestructure.Data.Configurations
{
    public class CuentaConfiguration : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.HasKey(e => new { e.Id, e.Codigo });

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Codigo)
                .HasColumnName("codigo")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.CodigoCliente)
                .IsRequired()
                .HasColumnName("codigoCliente")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Saldo).HasColumnName("saldo");

            builder.Property(e => e.Tipo)
                .HasColumnName("tipo")
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}
