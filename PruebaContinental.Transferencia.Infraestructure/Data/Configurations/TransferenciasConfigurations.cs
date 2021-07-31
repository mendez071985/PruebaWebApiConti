using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaContinental.Transferencia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Transferencia.Infraestructure.Data.Configurations
{
    public class TransferenciasConfigurations : IEntityTypeConfiguration<Transferencias>
    {
        public void Configure(EntityTypeBuilder<Transferencias> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id");
            var converter = new ValueConverter<Conceptos, string>(
                v => v.ToString(),
                v => (Conceptos)Enum.Parse(typeof(Conceptos),v)
                );
            builder.Property(e => e.Concepto)
                .HasColumnName("concepto")
                .HasConversion(converter)
                 .IsUnicode(false);

            builder.Property(e => e.Destino)
                .HasColumnName("destino")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Monto).HasColumnName("monto");

            builder.Property(e => e.Origen)
                .HasColumnName("origen")
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
