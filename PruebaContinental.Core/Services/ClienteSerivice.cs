using PruebaContinental.Core.Entities;
using PruebaContinental.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaContinental.Core.Services
{
    public class ClienteSerivice : IClienteSerivice
    {
        private readonly IClienteRepository _iClienteRepository;
        public ClienteSerivice(IClienteRepository iClienteRepository)
        {
            _iClienteRepository = iClienteRepository;
        }

        public async Task<bool> DeleteCliente(string codigo)
        {
            return await _iClienteRepository.DeleteCliente(codigo);
        }

        public async Task<Cliente> GetCliente(string codigo)
        {
            return await _iClienteRepository.GetCliente(codigo);
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _iClienteRepository.GetClientes();
        }

        public async Task InsertPost(Cliente cliente)
        {
           var cliInsert = await _iClienteRepository.GetCliente(cliente.Codigo);
            if (cliInsert != null)
            {
                throw new Exception("El cliente ya existe");
            }
            await _iClienteRepository.InsertPost(cliente);

        }

        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            return await _iClienteRepository.UpdateCliente(cliente);
        }
    }
}
