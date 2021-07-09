using Microsoft.EntityFrameworkCore;
using PruebaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebApi.Entities
{
    public class PostDbContext: DbContext
    {
        //Tablas de datos
        public  DbSet<Cliente> Clientes { get; set; }
        public  DbSet<Cuentas> Cuentas { get; set; }
        public  DbSet<SolicitudTransferencia> SolicitudTransferencias { get; set; }

        //Constructor sin parametros
        public PostDbContext()
        {
        }
        //Constructor con parametros para la configuracion
        public PostDbContext(DbContextOptions<PostDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
