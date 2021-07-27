using PruebaContinental.Cliente.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaContinental.Cliente.Core.Interfaces
{
    public interface IClientesRepository
    {
        Task<IEnumerable<Clientes>> Clientes();
        Task InsCliente(Clientes cliente);
        Task<Clientes> Cliente(string codigo);
        Task<bool> UpCliente(Clientes cliente);
        Task<bool> DelCliente(string codigo);
    }
}
