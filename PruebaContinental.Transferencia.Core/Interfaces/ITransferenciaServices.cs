using PruebaContinental.Transferencia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaContinental.Transferencia.Core.Interfaces
{
    public interface ITransferenciaServices
    {
        Task<string> transferencia(TransParametrosDTOs TransParam);
        Task<IEnumerable<TransferenciaReporteDTOs>> transferenciaReporte(string cuenta);

    }
}
