using PruebaContinental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaContinental.Core.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task InsertPost(Cliente cliente);
    }
}
