using BoostBusinessApi.Aplication.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoostBusinessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        //[HttpGet]
        //public async Task<ActionResult> Get()
        //{
        //    var users = await _uow.UserRepository.GetAll();
        //    return Ok(users);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult> Get(int id)
        //{
        //    var users = await _uow.UserRepository.Find(x => x.Id == id);
        //    return Ok(users);
        //}

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserCreateRequest userCreateRequest)
        {
            var result = await _mediator.Send(userCreateRequest);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserUpdateRequest userUpdateRequest)
        {
            var result = await _mediator.Send(userUpdateRequest);
            return Ok(result);
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        _uow.UserRepository.Delete(id);
        //        await _uow.Commit();
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound();
        //    }

        //}

    }
}
