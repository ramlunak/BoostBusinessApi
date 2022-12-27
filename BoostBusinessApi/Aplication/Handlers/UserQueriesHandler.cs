using BoostBusinessApi.Aplication.Queries;
using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Repository.Interface;
using BoostBusinessApi.ViewModel;
using MediatR;

namespace BoostBusinessApi.Aplication.Handlers
{
    public class UserQueriesHandler : IRequestHandler<UserQuery, IEnumerable<UserEntity>>
    {
        private readonly IUnitOfWork _uow;

        public UserQueriesHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<UserEntity>> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            return await _uow.UserRepository.Find(x => x.Id > 0);
        }
    }
}
