using PruebaContinental.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaContinental.Core.Interfaces
{
    public interface IClienteSerivice
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task InsertPost(Cliente cliente);
        Task<Cliente> GetCliente(string codigo);
        Task<bool> UpdateCliente(Cliente cliente);
        Task<bool> DeleteCliente(string codigo);
    }
}