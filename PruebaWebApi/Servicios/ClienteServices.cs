using PruebaWebApi.Entities;
using PruebaWebApi.Interfaces;
using PruebaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebApi.Servicios
{
    public class ClienteServices : ICliente
    {
        private readonly PostDbContext postDbContext;
        public ClienteServices(PostDbContext postDbContext)
        {
            this.postDbContext = postDbContext;
        }

        public Cliente registrar(Cliente cliente)
        {
            try
            {
                var client = postDbContext.Clientes.Where(x => x.Codigo == cliente.Codigo).Count();
                 cliente.Id = postDbContext.Clientes.Count() + 1;
                if (client == 0)
                {
                    postDbContext.Clientes.Add(cliente);
                    postDbContext.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("El codigo de cliente ya existe.");
                }
            }
            catch (Exception)
            {
                new ArgumentNullException();
            }
            return cliente;
        }

        public string borrar(int id)
        {
            var existe = "";
            try
            {
                Cliente cliente = postDbContext.Clientes.Find(id);
                if (cliente != null)
                {
                    postDbContext.Clientes.Remove(cliente);
                    postDbContext.SaveChanges();
                    existe = "El cliente ha sido borrado.";
                }
                else
                {
                    existe = "El cliente no ha sido borrado o no existe.";
                }
            }
            catch (Exception)
            {
                new ArgumentNullException();
            }
            return existe;
        }

        public Cliente modificar(Cliente modificarcliente)
        {
            try
            {
                var client = postDbContext.Clientes.Attach(modificarcliente);
                client.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                postDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new ArgumentNullException();
            }

            return modificarcliente;

        }

    }
}
