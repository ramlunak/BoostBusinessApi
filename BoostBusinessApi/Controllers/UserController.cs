using AutoMapper;
using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Model.User;
using BoostBusinessApi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BoostBusinessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            this._uow = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var users = await _uow.UserRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var users = await _uow.UserRepository.Find(x => x.Id == id);
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserCreateModel userCreate)
        {
            var user = _mapper.Map<UserEntity>(userCreate);
            _uow.UserRepository.Add(user);
            await _uow.Commit();
            return Ok(user);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserCreateModel userCreate)
        {
            var user = _mapper.Map<UserEntity>(userCreate);
            user.Id = id;
            _uow.UserRepository.Update(user);
            await _uow.Commit();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _uow.UserRepository.Delete(id);
                await _uow.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

    }
}
