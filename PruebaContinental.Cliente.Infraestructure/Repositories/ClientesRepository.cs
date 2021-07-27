using Microsoft.EntityFrameworkCore;
using PruebaContinental.Cliente.Core.Entities;
using PruebaContinental.Cliente.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using PruebaContinental.Cliente.Core.Interfaces;

namespace PruebaContinental.Cliente.Infraestructure.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly ClienteContext _context;
        public ClientesRepository(ClienteContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Clientes>> Clientes()
        {
            var clientes = await _context.Cliente.ToListAsync();
            return clientes;
        }

        public async Task InsCliente(Clientes cliente)
        {
            var countCliente = (from p in _context.Cliente
                                where p.Codigo.Trim() == cliente.Codigo.Trim()
                                select p).ToList();

            if (countCliente.Count == 0)
            {
                var countId = (from p in _context.Cliente
                               select p).ToList();
                cliente.Id = countId.Max(x => x.Id) + 1;

                _context.Cliente.Add(cliente);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Clientes> Cliente(string codigo)
        {
            var cliente = _context.Cliente.FirstOrDefaultAsync(x => x.Codigo == codigo);

            return await cliente;
        }

        public async Task<bool> UpCliente(Clientes cliente)
        {
            var currentCliente = await Cliente(cliente.Codigo);
            currentCliente.Codigo = cliente.Codigo;
            currentCliente.Nombre = cliente.Nombre;
            currentCliente.Apellido = cliente.Apellido;
            currentCliente.Direccion = cliente.Direccion;
            currentCliente.Estado = cliente.Estado;
            currentCliente.Telefono = cliente.Telefono;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DelCliente(string codigo)
        {
            var currentCliente = await Cliente(codigo);
            _context.Cliente.Remove(currentCliente);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

    }
}
