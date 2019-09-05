

using Core.Infrastructure.Domain.Repository;

namespace Core.Infrastructure.Domain.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly Context.Context.InfrastructureContext context;
        //private RefTypeRepository RefTypeRepository;

        public RepositoryWrapper(Context.Context.InfrastructureContext Context)
        {
            context = Context;
        }

        //public IRefTypeRepository RefTypeRepository
        //{
        //    get
        //    {
        //        if (RefTypeRepository == null) RefTypeRepository = new RefTypeRepository(context);

        //        return RefTypeRepository;
        //    }
        //}
    }
}