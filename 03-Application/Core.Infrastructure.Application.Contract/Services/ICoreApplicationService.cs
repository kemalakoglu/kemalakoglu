using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Infrastructure.Application.Contract.DTO;
using Core.Infrastructure.Application.Contract.DTO.RefType;
using Core.Infrastructure.Application.Contract.DTO.RefValue;
using Microsoft.AspNetCore.Identity;

namespace Core.Infrastructure.Application.Contract.Services
{
    public interface ICoreApplicationService
    {
        Task<IdentityUser> GetUserByMail(RegisterDTO request);
        ResponseDTO<RefTypeDTO> UpdateRefType(RefTypeDTO request);
        ResponseListDTO<RefTypeDTO> GetRefTypesByParent(long parentId);
        ResponseDTO<AddRefTypeResponseDTO> AddRefType(AddRefTypeRequestDTO request);
        ResponseDTO<RefTypeDTO> DeleteRefType(long parentId);
        ResponseDTO<RefTypeDTO> SoftDeleteRefType(long id);
        ResponseListDTO<RefValueDTO> GeRefValuesByRefTypeId(long refTypeId);
        ResponseDTO<AddRefValueResponseDTO> AddRefValue(AddRefValueRequestDTO refValue);
        ResponseListDTO<RefValueDTO> GetRefValuesByPage();
        ResponseDTO<RefValueDTO> DeleteRefValue(RefValueDTO request);
        ResponseDTO<RefValueDTO> UpdateRefValue(RefValueDTO request);
        ResponseDTO<RefValueDTO> SoftDeleteRefValue(RefValueDTO request);
    }
}
