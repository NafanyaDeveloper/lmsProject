using LMS.DATA.Dto;
using LMS.DATA.Entities;
using LMS.DATA.Supervisor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    public class DirectionController: Controller
    {
        private readonly ILMSSupervisor _supervisor;

        public DirectionController(ILMSSupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Produces(typeof(List<DirectionDto>))]
        public async Task<ActionResult<List<DirectionDto>>> Get()
        {
            try
            {
                return Ok(await _supervisor.GetAllDirectionAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(DirectionDto))]
        public async Task<ActionResult<DirectionDto>> Get(Guid id)
        {
            try
            {
                DirectionDto direction = await _supervisor.GetDirectionByIdAsync(id);
                if (direction == null)
                    return NotFound();
                return Ok(direction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(DirectionDto))]
        public async Task<ActionResult<DirectionDto>> Post([FromBody] DirectionDto item)
        {
            try
            {
                if (item == null)
                    return BadRequest();
                return Ok(await _supervisor.CreateDirectionAsync(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Produces(typeof(DirectionDto))]
        public async Task<ActionResult<DirectionDto>> Put([FromBody] DirectionDto item)
        {
            try
            {
                if (item == null || item.Id == null)
                    return BadRequest();
                if (await _supervisor.UpdateDirectionAsync(item))
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
                if (await _supervisor.DeleteDirectionAsync(id))
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
