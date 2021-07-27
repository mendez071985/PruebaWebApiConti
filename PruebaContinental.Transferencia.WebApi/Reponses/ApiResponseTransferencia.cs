using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaContinental.Transferencia.WebApi.Reponses
{
    public class ApiResponseTransferencia<T>
    {
        public ApiResponseTransferencia(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}
