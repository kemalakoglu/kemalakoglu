using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AutoMapper;
using Core.Infrastructure.Core.Contract;
using Core.Infrastructure.Core.Helper;
using Core.Infrastructure.Domain.Contract.DTO.Blog;
using Core.Infrastructure.Domain.Contract.DTO.RefValue;
using Remotion.Linq.Utilities;

namespace Core.Infrastructure.Domain.Aggregate.RefTypeValue
{
    public class RefValueService : IRefValueService
    {
        private readonly IUnitOfWork uow;

        /// <summary>
        /// Initializes a new instance of the <see cref="RefValueService"/> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        public RefValueService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// Gets the by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public ResponseDTO<RefValueDTO> GetByKey(long key)
        {
            return CreateResponse<RefValueDTO>.Return(Mapper.Map(this.uow.Repository<RefValue>().GetByKey(key), new RefValueDTO()), "GetByKey");
        }

        /// <summary>
        /// Creates the specified dto.
        /// </summary>
        /// <param name="DTO">The dto.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ResponseDTO<RefValueDTO> Create(RefValueDTO DTO)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the specified dto.
        /// </summary>
        /// <param name="DTO">The dto.</param>
        /// <returns></returns>
        public ResponseDTO<AddRefValueResponseDTO> Create(AddRefValueRequestDTO DTO)
        {
            RefValue entity = new RefValue(DTO.Value, true, DateTime.Now, null, DTO.IsActive, this.uow.Repository<RefType>().GetByKey(DTO.RefTypeId), DTO.Name, DTO.Description, DTO.Image, DTO.ImageText);
            this.uow.Repository<RefValue>().Create(entity);
            this.uow.EndTransaction();
            return CreateResponse<AddRefValueResponseDTO>.Return(new AddRefValueResponseDTO { Succeed = true }, "Create");
        }

        /// <summary>
        /// Gets the reference values by page.
        /// </summary>
        /// <returns></returns>
        public ResponseListDTO<RefValueDTO> GetRefValuesByPage()
        {
            IEnumerable<RefValue> entityList =
                this.uow.Repository<RefValue>().Query().Filter(x => x.RefType.Parent.Id == 1).Get();
            this.uow.EndTransaction();

            return CreateResponse<RefValueDTO>.Return(Mapper.Map<RefValue[], RefValueDTO[]>(entityList.ToArray()),
                "GetRefValuesByPage");
        }

        /// <summary>
        /// Gets the last by number.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        public ResponseListDTO<RefValueDTO> GetLastByNumber(int i)
        {
            IEnumerable<RefValue> entityList =
                this.uow.Repository<RefValue>().Query().Filter(x => x.RefType.Parent.Id == 1).Get().TakeLast(i);
            this.uow.EndTransaction();

            return CreateResponse<RefValueDTO>.Return(Mapper.Map<RefValue[], RefValueDTO[]>(entityList.ToArray()),
                "GetLastByNumber");
        }

        /// <summary>
        /// Gets the reference value by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ResponseDTO<RefValueDTO> GetRefValueById(long id)
        {
            var entity = this.uow.Repository<RefValue>().Query().Filter(x => x.Id == id).Get().FirstOrDefault();

            return CreateResponse<RefValueDTO>.Return(Mapper.Map(entity, new RefValueDTO()), "GetByRefTypeId");
        }

        /// <summary>
        /// Gets the archives.
        /// </summary>
        /// <returns></returns>
        public ResponseDTO<IEnumerable<ArchivesDTO>> GetArchives()
        {
            List<ArchivesDTO> response= new List<ArchivesDTO>();
            var entity = this.uow.Repository<RefValue>().Get().GroupBy(x=> new{ x.InsertDate.Value.Year, x.InsertDate.Value.Month });
            foreach (var item in entity)
            {
                ArchivesDTO responseItem = new ArchivesDTO
                {
                    Title =
                        new DateTime(item.Key.Year, item.Key.Month, 1).ToString("MMM", CultureInfo.InvariantCulture) +
                        " " + item.Key.Year,
                    Url = "Archive?Year="+item.Key.Year +"&Month="+item.Key.Month
                };
                response.Add(responseItem);
            }

            return CreateResponse<IEnumerable<ArchivesDTO>>.Return(response, "GetArchives");
        }

        /// <summary>
        /// Gets the reference value for blogs by archive.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public ResponseDTO<IEnumerable<RefValueDTO>> GetRefValueForBlogsByArchive(string year, string month)
        {
            var entity = this.uow.Repository<RefValue>().Query().Filter(x =>
                x.InsertDate.Value.Month == Convert.ToInt32(month) && x.InsertDate.Value.Year == Convert.ToInt32(year)).Get();
            return CreateResponse<IEnumerable<RefValueDTO>>.Return(Mapper.Map<RefValue[],RefValueDTO[]>(entity.ToArray()), "GetRefValueForBlogsByArchive");
        }

        /// <summary>
        /// Updates the specified dto.
        /// </summary>
        /// <param name="DTO">The dto.</param>
        /// <returns></returns>
        public ResponseDTO<RefValueDTO> Update(RefValueDTO DTO)
        {
            RefValue entity = this.uow.Repository<RefValue>().GetByKey(DTO.Id);
            entity.Update(DTO.Name, DTO.IsActive,
                this.uow.Repository<RefType>().GetByKey(DTO.RefType.Id), DTO.Value, DTO.Description, DTO.Image, DTO.ImageText);
            this.uow.Repository<RefValue>().Update(entity);
            this.uow.EndTransaction();
            DTO.UpdateDate = entity.UpdateDate;
            return CreateResponse<RefValueDTO>.Return(DTO, "Update RefValue");
        }

        /// <summary>
        /// Deletes the specified dto.
        /// </summary>
        /// <param name="DTO">The dto.</param>
        /// <returns></returns>
        public ResponseDTO<RefValueDTO> Delete(RefValueDTO DTO)
        {
            RefValue entity= this.uow.Repository<RefValue>().GetByKey(DTO.Id);
            this.uow.Repository<RefValue>().Delete(entity);
            this.uow.EndTransaction();
            return CreateResponse<RefValueDTO>.Return(DTO,
                "GetRefValuesByPage");
        }

        /// <summary>
        /// Softs the delete.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public ResponseDTO<RefValueDTO> SoftDelete(long Id)
        {
            RefValue entity = this.uow.Repository<RefValue>().GetByKey(Id);
            entity.SetStatus(false);
            this.uow.Repository<RefValue>().Update(entity);
            this.uow.EndTransaction();
            return CreateResponse<RefValueDTO>.Return(Mapper.Map<RefValueDTO>(entity),
                "GetRefValuesByPage");
        }

        /// <summary>
        /// Gets the by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public ResponseListDTO<RefValueDTO> GetByRefTypeId(long refTypeId)
        {
            var entity = this.uow.Repository<RefValue>().Query().Filter(x => x.RefType.Id == refTypeId).Get();
           
            return CreateResponse<RefValueDTO>.Return(Mapper.Map<RefValue[],RefValueDTO[]>(entity.ToArray()), "GetByRefTypeId");
        }
    }
}
