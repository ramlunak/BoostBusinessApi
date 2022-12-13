using AutoMapper;
using BoostBusinessApi.Controllers;
using BoostBusinessApi.Repository.Interface;
using Moq;

namespace BoostBusinessApiTest.UserTests
{
    [TestClass]
    public class UserTest
    {

        private UserController _userController;
        private Mock<IUserRepository> _userRepository;
        private Mock<IDBTransaction> _dbTransaction;
        private Mock<IMapper> _mapper;

        public UserTest()
        {
            _userRepository = new Mock<IUserRepository>();
            _dbTransaction = new Mock<IDBTransaction>();
            _mapper = new Mock<IMapper>();
        }

        [TestMethod]
        public void GetTest()
        {

            var _userController = new UserController(_userRepository.Object, _dbTransaction.Object, _mapper.Object);

            var user = _userController.Get();

            Assert.IsNotNull(user);

        }
    }
}