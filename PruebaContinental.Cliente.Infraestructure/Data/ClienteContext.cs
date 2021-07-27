using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Text;
using PruebaContinental.Cliente.Core.Entities;

namespace PruebaContinental.Cliente.Infraestructure.Data
{
    public  class ClienteContext : DbContext
    {
        public ClienteContext()
        {
        }

        public ClienteContext(DbContextOptions<ClienteContext> options)
            : base(options)
        {
        }
        public  DbSet<Clientes> Cliente { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
