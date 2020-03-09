using System;
using System.Collections.Generic;
using System.Text;
using Core.Infrastructure.Core.Helper;
using Core.Infrastructure.Domain.Aggregate.Base;
using Core.Infrastructure.Domain.Contract.DTO.RefValue;

namespace Core.Infrastructure.Domain.Aggregate.RefTypeValue
{
    public interface IRefValueService: IBaseService<RefValueDTO>
    {
        ResponseListDTO<RefValueDTO> GetByRefTypeId(long refTypeId);
        ResponseDTO<AddRefValueResponseDTO> Create(AddRefValueRequestDTO DTO);
        ResponseListDTO<RefValueDTO> GetRefValuesByPage();
        ResponseListDTO<RefValueDTO> GetLastByNumber(int i);
        ResponseDTO<RefValueDTO> GetRefValueById(long id);
    }
}
