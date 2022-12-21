using AutoMapper;
using BoostBusinessApi.Aplication.Commands;
using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Model;
using BoostBusinessApi.Repository.Interface;
using MediatR;
using BoostBusinessApi.Extension;

namespace BoostBusinessApi.Aplication.Handlers
{
    public class UserHandlers :
        IRequestHandler<UserCreateRequest, ApiModelResponse>,
        IRequestHandler<UserUpdateRequest, ApiModelResponse>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserHandlers(IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiModelResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UserEntity>(request);
            _uow.UserRepository.Add(entity);
            await _uow.Commit();
            return entity.AsApiModelResponse();
        }

        public async Task<ApiModelResponse> Handle(UserUpdateRequest request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<UserEntity>(request);
            _uow.UserRepository.Update(entity);
            await _uow.Commit();
            return entity.AsApiModelResponse();
        }
    }
}
