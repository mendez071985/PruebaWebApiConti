﻿using Microsoft.EntityFrameworkCore;
using PruebaContinental.Core.Entities;
using PruebaContinental.Core.Interfaces;
using PruebaContinental.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaContinental.Infraestructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PruebaContext _context;
        public ClienteRepository(PruebaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            var clientes = await _context.Cliente.ToListAsync();
            return clientes;
        }
        public async Task InsertPost (Cliente cliente)
        {
            var countCliente = (from p in _context.Cliente
                                where p.Codigo == cliente.Codigo select p).ToList();
            if (countCliente.Count == 0)
            {
                var countId = (from p in _context.Cliente
                                    select p).ToList();
                cliente.Id = countId.Max( x => x.Id) + 1;
                _context.Cliente.Add(cliente);
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
