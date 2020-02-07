using System;
using System.Collections.Generic;
using System.Text;
using Core.Infrastructure.Core.Helper;
using Core.Infrastructure.Domain.Aggregate.Base;
using Core.Infrastructure.Domain.Contract.DTO.RefType;

namespace Core.Infrastructure.Domain.Aggregate.RefTypeValue
{
    public interface IRefTypeService: IBaseService<RefTypeDTO>
    {
        ResponseListDTO<RefTypeDTO> GetByParent(long parentId);
        ResponseDTO<AddRefTypeResponseDTO> Create(AddRefTypeRequestDTO DTO);
    }
}
