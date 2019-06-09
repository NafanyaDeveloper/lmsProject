using LMS.DATA.Dto;
using LMS.DATA.Entities;
using LMS.DATA.Supervisor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    public class AdministrationController: Controller
    {
        private readonly ILMSSupervisor _supervisor;

        public AdministrationController(ILMSSupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        [HttpGet]
        [Produces(typeof(List<AdministrationDto>))]
        public async Task<ActionResult<List<AdministrationDto>>> Get()
        {
            try
            {
                return Ok(await _supervisor.GetAllAdministrationAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{userId}/{directionId}")]
        [Produces(typeof(AdministrationDto))]
        public async Task<ActionResult<AdministrationDto>> Get(Guid userId, Guid directionId)
        {
            try
            {
                AdministrationDto administration = await _supervisor.GetAdministrationByIdAsync(userId, directionId);
                if (administration == null)
                    return NotFound();
                return Ok(administration);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("user/{id}")]
        [Produces(typeof(List<AdministrationDto>))]
        public async Task<ActionResult<List<AdministrationDto>>> GetByUser(Guid id)
        {
            try
            {
                UserDto user = await _supervisor.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound();
                return Ok(await _supervisor.GetAdministrationByUserIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("direction/{id}")]
        [Produces(typeof(List<AdministrationDto>))]
        public async Task<ActionResult<List<AdministrationDto>>> GetByDirection(Guid id)
        {
            try
            {
                DirectionDto direction = await _supervisor.GetDirectionByIdAsync(id);
                if (direction == null)
                    return NotFound();
                return Ok(await _supervisor.GetAdministrationByDirectionIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("role/{id}")]
        [Produces(typeof(List<AdministrationDto>))]
        public async Task<ActionResult<List<AdministrationDto>>> GetByRole(Guid id)
        {
            try
            {
                AdministrationRole role = await _supervisor.GetAdministrationRoleByIdAsync(id);
                if (role == null)
                    return NotFound();
                return Ok(await _supervisor.GetAdministrationByRoleIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(AdministrationDto))]
        public async Task<ActionResult<AdministrationDto>> Post([FromBody] AdministrationDto item)
        {
            try
            {
                if (item.UserId == null || item.DirectionId == null || item.AdministrationRoleId == null)
                    return BadRequest();
                return Ok(await _supervisor.CreateAdministrationAsync(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Produces(typeof(AdministrationDto))]
        public async Task<ActionResult<AdministrationDto>> Put([FromBody] AdministrationDto item)
        {
            try
            {
                if (item.UserId == null || item.DirectionId == null || item.AdministrationRoleId == null)
                    return BadRequest();
                if (await _supervisor.UpdateAdministrationAsync(item))
                    return Ok(item);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{userId}/{directionId}")]
        [Produces(typeof(bool))]
        public async Task<ActionResult<bool>> Delete(Guid userId, Guid directionId)
        {
            try
            {
                if (userId == null || directionId == null)
                    return BadRequest();
                if (await _supervisor.DeleteAdministrationAsync(userId, directionId))
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
