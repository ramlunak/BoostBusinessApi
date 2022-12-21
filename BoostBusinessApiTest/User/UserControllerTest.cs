using AutoMapper;
using BoostBusinessApi.Controllers;
using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BoostBusinessApiTest.User
{
    public class UserControllerTest
    {      
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
        private readonly IMapper _mapper;
        private readonly UserController _userController;

        public UserControllerTest()
        {
            //var configuration = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<UserCreateModel, UserEntity>();
            //});
            //_mapper = new Mapper(configuration);

            //_unitOfWork.Setup(uow => uow.UserRepository).Returns(_userRepository.Object);

            //_userController = new UserController(_unitOfWork.Object, _mapper);

        }

        [Fact]
        public async void PostTest()
        {
            //var newuser = new UserCreateModel("royber", "sdfsdf");
           
            //var result = await _userController.Post(newuser);
            //Assert.IsType<OkObjectResult>(result);

        }
    }
}
