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
    public class CourseController: Controller
    {
        private readonly ILMSSupervisor _supervisor;

        public CourseController(ILMSSupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        [HttpGet]
        [Produces(typeof(List<CourseDto>))]
        public async Task<ActionResult<List<CourseDto>>> Get()
        {
            try
            {
                return Ok(await _supervisor.GetAllCourseAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(CourseDto))]
        public async Task<ActionResult<CourseDto>> Get(Guid id)
        {
            try
            {
                CourseDto course = await _supervisor.GetCourseByIdAsync(id);
                if (course == null)
                    return NotFound();
                return Ok(course);
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
                return Ok(await _supervisor.GetCourseByDirectionIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(CourseDto))]
        public async Task<ActionResult<CourseDto>> Post([FromBody] CourseDto item)
        {
            try
            {
                if (item == null)
                    return BadRequest();
                return Ok(await _supervisor.CreateCourseAsync(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Produces(typeof(CourseDto))]
        public async Task<ActionResult<CourseDto>> Put([FromBody] CourseDto item)
        {
            try
            {
                if (item == null || item.Id == null)
                    return BadRequest();
                if (await _supervisor.UpdateCourseAsync(item))
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
                if (await _supervisor.DeleteCourseAsync(id))
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
