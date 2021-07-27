using Microsoft.EntityFrameworkCore;
using PruebaContinental.Transferencia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PruebaContinental.Transferencia.Infraestructure.Data
{
    public class TransferenciaContext : DbContext
    {
        public TransferenciaContext()
        {
        }

        public TransferenciaContext(DbContextOptions<TransferenciaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Cliente { get; set; }
        public virtual DbSet<Cuentas> Cuenta { get; set; }
        public virtual DbSet<Transferencias> Transferencia { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
