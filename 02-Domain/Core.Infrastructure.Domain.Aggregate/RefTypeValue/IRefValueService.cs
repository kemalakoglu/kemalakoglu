using System;
using System.Collections.Generic;
using System.Text;
using Core.Infrastructure.Application.Contract.DTO;
using Core.Infrastructure.Application.Contract.DTO.RefValue;
using Core.Infrastructure.Domain.Aggregate.Base;

namespace Core.Infrastructure.Domain.Aggregate.RefTypeValue
{
    public interface IRefValueService: IBaseService<RefValueDTO>
    {
        ResponseListDTO<RefValueDTO> GetByRefTypeId(long refTypeId);
        ResponseDTO<AddRefValueResponseDTO> Create(AddRefValueRequestDTO DTO);
    }
}
