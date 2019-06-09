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
    public class QuestionController: Controller
    {
        private readonly ILMSSupervisor _supervisor;

        public QuestionController(ILMSSupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        [HttpGet]
        [Produces(typeof(List<QuestionDto>))]
        public async Task<ActionResult<List<QuestionDto>>> Get()
        {
            try
            {
                return Ok(await _supervisor.GetAllQuestionAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(QuestionDto))]
        public async Task<ActionResult<QuestionDto>> Get(Guid id)
        {
            try
            {
                QuestionDto question = await _supervisor.GetQuestionByIdAsync(id);
                if (question == null)
                    return NotFound();
                return Ok(question);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("block/{id}")]
        [Produces(typeof(List<AdministrationDto>))]
        public async Task<ActionResult<List<AdministrationDto>>> GetByBlock(Guid id)
        {
            try
            {
                BlockDto block = await _supervisor.GetBlockByIdAsync(id);
                if (block == null)
                    return NotFound();
                return Ok(await _supervisor.GetQuestionByBlockIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(QuestionDto))]
        public async Task<ActionResult<QuestionDto>> Post([FromBody] QuestionDto item)
        {
            try
            {
                if (item == null)
                    return BadRequest();
                return Ok(await _supervisor.CreateQuestionAsync(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Produces(typeof(QuestionDto))]
        public async Task<ActionResult<QuestionDto>> Put([FromBody] QuestionDto item)
        {
            try
            {
                if (item == null || item.Id == null)
                    return BadRequest();
                if (await _supervisor.UpdateQuestionAsync(item))
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
                if (await _supervisor.DeleteQuestionAsync(id))
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
