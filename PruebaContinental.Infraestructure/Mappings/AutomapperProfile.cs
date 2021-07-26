using AutoMapper;
using PruebaContinental.Core.DTOs;
using PruebaContinental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Cliente, ClienteDTOs>();
            CreateMap<ClienteDTOs, Cliente>();
        }
    }
}
