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
    public class ParticipantController: Controller
    {
        private readonly ILMSSupervisor _supervisor;

        public ParticipantController(ILMSSupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        [HttpGet]
        [Produces(typeof(List<ParticipantDto>))]
        public async Task<ActionResult<List<ParticipantDto>>> Get()
        {
            try
            {
                return Ok(await _supervisor.GetAllParticipantAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{userId}/{groupId}")]
        [Produces(typeof(ParticipantDto))]
        public async Task<ActionResult<ParticipantDto>> Get(Guid userId, Guid groupId)
        {
            try
            {
                ParticipantDto participant = await _supervisor.GetParticipantByIdAsync(userId, groupId);
                if (participant == null)
                    return NotFound();
                return Ok(participant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("user/{id}")]
        [Produces(typeof(List<ParticipantDto>))]
        public async Task<ActionResult<List<ParticipantDto>>> GetByUser(Guid id)
        {
            try
            {
                UserDto user = await _supervisor.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound();
                return Ok(await _supervisor.GetParticipantByUserIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("group/{id}")]
        [Produces(typeof(List<ParticipantDto>))]
        public async Task<ActionResult<List<ParticipantDto>>> GetByGroup(Guid id)
        {
            try
            {
                GroupDto group = await _supervisor.GetGroupByIdAsync(id);
                if (group == null)
                    return NotFound();
                return Ok(await _supervisor.GetParticipantByGroupIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("role/{id}")]
        [Produces(typeof(List<ParticipantDto>))]
        public async Task<ActionResult<List<ParticipantDto>>> GetByRole(Guid id)
        {
            try
            {
                ParticipantRole role = await _supervisor.GetParticipantRoleByIdAsync(id);
                if (role == null)
                    return NotFound();
                return Ok(await _supervisor.GetParticipantByRoleIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(ParticipantDto))]
        public async Task<ActionResult<ParticipantDto>> Post([FromBody] ParticipantDto item)
        {
            try
            {
                if (item.UserId == null || item.GroupId == null || item.ParticipantRoleId == null)
                    return BadRequest();
                return Ok(await _supervisor.CreateParticipantAsync(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Produces(typeof(ParticipantDto))]
        public async Task<ActionResult<ParticipantDto>> Put([FromBody] ParticipantDto item)
        {
            try
            {
                if (item.UserId == null || item.GroupId == null || item.ParticipantRoleId == null)
                    return BadRequest();
                if (await _supervisor.UpdateParticipantAsync(item))
                    return Ok(item);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{userId}/{groupId}")]
        [Produces(typeof(bool))]
        public async Task<ActionResult<bool>> Delete(Guid userId, Guid groupId)
        {
            try
            {
                if (userId == null || groupId == null)
                    return BadRequest();
                if (await _supervisor.DeleteParticipantAsync(userId, groupId))
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
