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
                cfg.CreateMap<RefType,RefTypeDTO>().ForMember(x=>x.Parent, opt=>opt.MapFrom(y=>y.Parent));
              
                cfg.CreateMap<RefValue, RefValueDTO>().ForMember(x => x.RefType, opt => opt.MapFrom(y => y.RefType));

                cfg.CreateMap<AddRefTypeResponseDTO, AddRefTypeRequestDTO>();
            });
        }
    }
}