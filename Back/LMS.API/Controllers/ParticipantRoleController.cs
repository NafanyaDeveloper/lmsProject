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
    public class ParticipantRoleController: Controller
    {
        private readonly ILMSSupervisor _supervisor;

        public ParticipantRoleController(ILMSSupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        [HttpGet]
        [Produces(typeof(List<ParticipantRole>))]
        public async Task<ActionResult<List<ParticipantRole>>> Get()
        {
            try
            {
                return Ok(await _supervisor.GetAllParticipantRoleAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(ParticipantRole))]
        public async Task<ActionResult<ParticipantRole>> Get(Guid id)
        {
            try
            {
                ParticipantRole pRole = await _supervisor.GetParticipantRoleByIdAsync(id);
                if (pRole == null)
                    return NotFound();
                return Ok(pRole);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(ParticipantRole))]
        public async Task<ActionResult<ParticipantRole>> Post([FromBody] ParticipantRole item)
        {
            try
            {
                if (item == null)
                    return BadRequest();
                return Ok(await _supervisor.CreateParticipantRoleAsync(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Produces(typeof(ParticipantRole))]
        public async Task<ActionResult<ParticipantRole>> Put([FromBody] ParticipantRole item)
        {
            try
            {
                if (item == null || item.Id == null)
                    return BadRequest();
                if (await _supervisor.UpdateParticipantRoleAsync(item))
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
                if (await _supervisor.DeleteParticipantRoleAsync(id))
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
