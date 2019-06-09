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
    public class GroupController: Controller
    {
        private readonly ILMSSupervisor _supervisor;

        public GroupController(ILMSSupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        [HttpGet]
        [Produces(typeof(List<GroupDto>))]
        public async Task<ActionResult<List<GroupDto>>> Get()
        {
            try
            {
                return Ok(await _supervisor.GetAllGroupAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(GroupDto))]
        public async Task<ActionResult<GroupDto>> Get(Guid id)
        {
            try
            {
                GroupDto group = await _supervisor.GetGroupByIdAsync(id);
                if (group == null)
                    return NotFound();
                return Ok(group);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("course/{id}")]
        [Produces(typeof(List<AdministrationDto>))]
        public async Task<ActionResult<List<AdministrationDto>>> GetByCourse(Guid id)
        {
            try
            {
                CourseDto course = await _supervisor.GetCourseByIdAsync(id);
                if (course == null)
                    return NotFound();
                return Ok(await _supervisor.GetGroupByCourseIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(GroupDto))]
        public async Task<ActionResult<GroupDto>> Post([FromBody] GroupDto item)
        {
            try
            {
                if (item == null)
                    return BadRequest();
                return Ok(await _supervisor.CreateGroupAsync(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Produces(typeof(GroupDto))]
        public async Task<ActionResult<GroupDto>> Put([FromBody] GroupDto item)
        {
            try
            {
                if (item == null || item.Id == null)
                    return BadRequest();
                if (await _supervisor.UpdateGroupAsync(item))
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
                if (await _supervisor.DeleteGroupAsync(id))
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
