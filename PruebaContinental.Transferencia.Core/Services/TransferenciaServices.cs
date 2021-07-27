using PruebaContinental.Transferencia.Core.DTOs;
using PruebaContinental.Transferencia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaContinental.Transferencia.Core.Services
{
    public class TransferenciaServices : ITransferenciaServices
    {
        private readonly ITransferenciasRepository _iTransferenciasRepository;

        public TransferenciaServices(ITransferenciasRepository iTransferenciasRepository)
        {
            _iTransferenciasRepository = iTransferenciasRepository;
        }

        public async Task<string> transferencia(TransParametrosDTOs TransParam)
        {
            return await _iTransferenciasRepository.transferencia(TransParam);
        }
    }
}
