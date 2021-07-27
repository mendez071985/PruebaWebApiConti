using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaContinental.Cuenta.WebApi.Response
{
    public class ApiResponsesCuentas<T>
    {
        public ApiResponsesCuentas(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}
