using BoostBusinessApi.ViewModel;
using MediatR;

namespace BoostBusinessApi.Aplication.Queries
{
    public class UserQuery : IRequest<IEnumerable<UserViewModel>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
