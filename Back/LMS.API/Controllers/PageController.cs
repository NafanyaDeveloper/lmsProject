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
    public class PageController:Controller
    {
        private readonly ILMSSupervisor _supervisor;

        public PageController(ILMSSupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        [HttpGet]
        [Produces(typeof(List<PageDto>))]
        public async Task<ActionResult<List<PageDto>>> Get()
        {
            try
            {
                return Ok(await _supervisor.GetAllPageAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(PageDto))]
        public async Task<ActionResult<PageDto>> Get(Guid id)
        {
            try
            {
                PageDto page = await _supervisor.GetPageByIdAsync(id);
                if (page == null)
                    return NotFound();
                return Ok(page);
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
                return Ok(await _supervisor.GetPageByCourseIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(PageDto))]
        public async Task<ActionResult<PageDto>> Post([FromBody] PageDto item)
        {
            try
            {
                if (item == null)
                    return BadRequest();
                return Ok(await _supervisor.CreatePageAsync(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Produces(typeof(PageDto))]
        public async Task<ActionResult<PageDto>> Put([FromBody] PageDto item)
        {
            try
            {
                if (item == null || item.Id == null)
                    return BadRequest();
                if (await _supervisor.UpdatePageAsync(item))
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
                if (await _supervisor.DeletePageAsync(id))
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
