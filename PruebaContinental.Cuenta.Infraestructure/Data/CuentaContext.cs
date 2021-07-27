using Microsoft.EntityFrameworkCore;
using PruebaContinental.Cuenta.Core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PruebaContinental.Cuenta.Infraestructure.Data
{
    public class CuentaContext : DbContext
    {
        public CuentaContext()
        {
        }

        public CuentaContext(DbContextOptions<CuentaContext> options)
            : base(options)
        {
        }

        public DbSet<Cuentas> Cuenta { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
