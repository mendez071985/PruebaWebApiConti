using AutoMapper;
using PruebaContinental.Cuenta.Core.DTOs;
using PruebaContinental.Cuenta.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Cuenta.Infraestructure.Mappings
{
    public class AutomapperProfilesCuenta : Profile
    {
        public AutomapperProfilesCuenta()
        {
            CreateMap<Cuentas, CuentasDto>();
            CreateMap<CuentasDto, Cuentas>();

        }
    }
}
