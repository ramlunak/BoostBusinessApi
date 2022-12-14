using AutoMapper;
using BoostBusinessApi.Controllers;
using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Model.User;
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
        public async void GetTest()
        {

            var _userController = new UserController(_userRepository.Object, _dbTransaction.Object, _mapper.Object);

            var user = await _userController.Get();

            Assert.IsNotNull(user);

        }

        [TestMethod]
        public async void PostTest()
        {

            var _userController = new UserController(_userRepository.Object, _dbTransaction.Object, _mapper.Object);
            var user = new UserCreateModel();
            user.Name = "Royber";
            var result = await Assert.ThrowsExceptionAsync<Exception>(async () =>  await _userController.Post(user));

            Assert.IsNotNull(user);

        }


        public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserCreateModel, UserEntity>();
         
            //CreateMap<ActorCreacionDTO, Actor>();
            //CreateMap<Actor, ActorDTO>();
            //CreateMap<ComentarioCreacionDTO, Comentario>();

            //CreateMap<PeliculaCreacionDTO, Pelicula>()
            //    .ForMember(ent => ent.Generos, dto =>
            //    dto.MapFrom(campo => campo.Generos.Select(id => new Genero { Id = id })));

            //CreateMap<PeliculaActorCreacionDTO, PeliculaActor>();
        }
    }

    }
}