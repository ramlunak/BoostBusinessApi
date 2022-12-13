using AutoMapper;
using BoostBusinessApi.Data;
using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Model.User;
using BoostBusinessApi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace BoostBusinessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IDBTransaction _dbTransaction;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository,
                              IDBTransaction dbTransaction,
                              IMapper mapper)
        {
            this._userRepository = userRepository;
            this._dbTransaction = dbTransaction;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var users = await _userRepository.GetAll();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var users = await _userRepository.Find(x => x.Id == id);
            return Ok(users);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserCreateModel userCreate)
        {
            var user = _mapper.Map<UserEntity>(userCreate);
            _userRepository.Add(user);
            await _dbTransaction.Commit();
            return Ok(user);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserCreateModel userCreate)
        {
            var user = _mapper.Map<UserEntity>(userCreate);
            user.Id = id;
            _userRepository.Update(user);
            await _dbTransaction.Commit();
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _userRepository.Delete(id);
                await _dbTransaction.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

    }
}
