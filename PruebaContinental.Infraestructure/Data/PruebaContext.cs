using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PruebaContinental.Core.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PruebaContinental.Infraestructure.Data
{
    public partial class PruebaContext : DbContext
    {
        public PruebaContext()
        {
        }

        public PruebaContext(DbContextOptions<PruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<Historial> Historial { get; set; }
        public virtual DbSet<Transferencia> Transferencia { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        // if (!optionsBuilder.IsConfigured)
        //{
         //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Prueba;Integrated Security=True;");
        //}
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<Cliente>(entity =>
            //{

            //});

            //modelBuilder.Entity<Cuenta>(entity =>
            //{

            //});

            //modelBuilder.Entity<Historial>(entity =>
            //{

            //});

            //modelBuilder.Entity<Transferencia>(entity =>
            //{

            //});

            // OnModelCreatingPartial(modelBuilder);
        }

       // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
