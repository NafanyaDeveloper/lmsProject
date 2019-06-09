using LMS.DATA.Dto;
using LMS.DATA.Supervisor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController: Controller
    {
        private readonly ILMSSupervisor _supervisor;

        public UserController(ILMSSupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        [HttpGet]
        [Produces(typeof(List<UserDto>))]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            try
            {
                return Ok(await _supervisor.GetAllUserAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(UserDto))]
        public async Task<ActionResult<UserDto>> Get(Guid id)
        {
            try
            {
                UserDto user = await _supervisor.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(UserDto))]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserDto item)
        {
            try
            {
                if (item == null)
                    return BadRequest();
                return Ok(await _supervisor.CreateUserAsync(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Produces(typeof(UserDto))]
        public async Task<ActionResult<UserDto>> Put([FromBody] UserDto item)
        {
            try
            {
                if (item == null || item.Id == null)
                    return BadRequest();
                if (await _supervisor.UpdateUserAsync(item))
                    return Ok(item);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        [Produces(typeof(bool))]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            try
            {
                if (id == null)
                    return BadRequest();
                if (await _supervisor.DeleteUserAsync(id))
                    return true;
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
