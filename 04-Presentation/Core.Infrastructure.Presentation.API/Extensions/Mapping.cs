using System.Collections.Generic;
using System.Linq;
using AutoMapper;


using Core.Infrastructure.Domain.Aggregate.RefTypeValue;
using Core.Infrastructure.Domain.Aggregate.User;
using Core.Infrastructure.Domain.Contract.DTO.Login;
using Core.Infrastructure.Domain.Contract.DTO.RefType;
using Core.Infrastructure.Domain.Contract.DTO.RefValue;

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
                cfg.CreateMap<UserDTO, ApplicationUser>();
            });
        }
    }
}