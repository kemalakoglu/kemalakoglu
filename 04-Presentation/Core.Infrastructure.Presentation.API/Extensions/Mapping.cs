using AutoMapper;
using Core.Infrastructure.Application.Contract.DTO.RefType;
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
                cfg.CreateMap<RefType,RefTypeDTO >()
                    .ForMember(x => x.ParentId, opt => opt.Ignore()).ForMember(x=>x.UpdateDate,opt=>opt.AllowNull());
                cfg.CreateMap<RefTypeDTO,RefType>()
                    .ForMember(x => x.Parent, opt => opt.Ignore());
            });
        }
    }
}