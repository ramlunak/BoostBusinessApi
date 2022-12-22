using BoostBusinessApi.ViewModel;
using MediatR;

namespace BoostBusinessApi.Aplication.Queries
{
    public class UserQuery : IRequest<IEnumerable<UserViewModel>>
    {
    }
}
