using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Infrastructure.Application.Contract.DTO.RefType;
using Core.Infrastructure.Application.Contract.DTO.RefValue;
using Core.Infrastructure.Domain.Aggregate.RefTypeValue;
using Core.Infrastructure.Domain.Context.Context;

namespace Core.Infrastructure.Presentation.API.Extensions
{
    public static class Mapping
    {
        public static void ConfigureMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<RefType, RefTypeDTO>();
                cfg.CreateMap<RefValue, RefValueDTO>();
                cfg.CreateMap<AddRefTypeResponseDTO, AddRefTypeRequestDTO>();
            });
        }
    }
}