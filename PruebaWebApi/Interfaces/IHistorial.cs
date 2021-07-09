using PruebaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebApi.Interfaces
{
    public interface IHistorial
    {
        ListaHistorial historialTransferencia(String Cuenta, String TipoTransferencia);
    }
}
