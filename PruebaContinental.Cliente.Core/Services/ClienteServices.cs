using PruebaContinental.Cliente.Core.Entities;
using PruebaContinental.Cliente.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaContinental.Cliente.Core.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClientesRepository _iClientesRepository;
        public ClienteServices(IClientesRepository iClientesRepository)
        {
            _iClientesRepository = iClientesRepository;
        }

        public async Task<bool> DelCliente(string codigo)
        {
            return await _iClientesRepository.DelCliente(codigo);
        }

        public async Task<Clientes> Cliente(string codigo)
        {
            return await _iClientesRepository.Cliente(codigo);
        }

        public async Task<IEnumerable<Clientes>> Clientes()
        {
            return await _iClientesRepository.Clientes();
        }

        public async Task InsCliente(Clientes cliente)
        {
            var cliInsert = await _iClientesRepository.Cliente(cliente.Codigo);
            if (cliInsert != null)
            {
                throw new Exception("El cliente ya existe");
            }
            await _iClientesRepository.InsCliente(cliente);

        }

        public async Task<bool> UpCliente(Clientes cliente)
        {
            return await _iClientesRepository.UpCliente(cliente);
        }

    }
}
