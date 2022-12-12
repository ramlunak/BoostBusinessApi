using AutoMapper;
using BoostBusinessApi.Data;
using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Model.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoostBusinessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DBContext db;
        private readonly IMapper mapper;

        public UserController(DBContext dataContext, IMapper mapper)
        {
            this.db = dataContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var users = db.Users.AsNoTracking().ToList();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var users = db.Users.Where(x => x.Id == id).AsNoTracking().ToList();
            return Ok(users);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserCreateModel userCreate)
        {
            var user = mapper.Map<UserEntity>(userCreate);
            db.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserCreateModel userCreate)
        {
            var user = mapper.Map<UserEntity>(userCreate);
            user.Id = id;
            db.Update(user);
            await db.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await db.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (result > 0)
                return Ok();
            else return NotFound();

        }

    }
}
