using AutoMapper;
using PruebaContinental.Cliente.Core.DTOs;
using PruebaContinental.Cliente.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Cliente.Infraestructure.Mappings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Clientes, ClientesDto>();
            CreateMap<ClientesDto, Clientes>();

        }
    }
}
