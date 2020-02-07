using Core.Infrastructure.Core.Helper;

namespace Core.Infrastructure.Domain.Aggregate.Base
{
    public interface IBaseService<T> where T : class
    {
        ResponseDTO<T> GetByKey(long key);
        ResponseDTO<T> Create(T DTO);
        ResponseDTO<T> Update(T DTO);
        ResponseDTO<T> Delete(T DTO);
        ResponseDTO<T> SoftDelete(long Id);
    }
}