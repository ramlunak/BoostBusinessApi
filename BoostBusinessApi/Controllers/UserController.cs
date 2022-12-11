using AutoMapper;
using BoostBusinessApi.Data;
using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Model.User;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserCreateModel userCreate)
        {
            try
            {
                var user = mapper.Map<UserEntity>(userCreate);
                db.Add(user);

                await db.SaveChangesAsync();
               
                return Ok(user);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
