using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaContinental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Infraestructure.Data.Configurations
{
    public class HistorialConfiguration : IEntityTypeConfiguration<Historial>
    {
        public void Configure(EntityTypeBuilder<Historial> builder)
        {
            builder.HasKey(e => e.Codigo);

            builder.Property(e => e.Codigo).HasColumnName("codigo");

            builder.Property(e => e.CuentaDestino)
                .HasColumnName("cuentaDestino")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.CuentaOrigen)
                .HasColumnName("cuentaOrigen")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Fecha)
                .HasColumnName("fecha")
                .HasColumnType("datetime");

            builder.Property(e => e.Monto).HasColumnName("monto");
        }
    }
}
