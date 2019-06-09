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
    public class AnswerController: Controller
    {
        private readonly ILMSSupervisor _supervisor;

        public AnswerController(ILMSSupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        [HttpGet]
        [Produces(typeof(List<AnswerDto>))]
        public async Task<ActionResult<List<AnswerDto>>> Get()
        {
            try
            {
                return Ok(await _supervisor.GetAllAnswerAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(AnswerDto))]
        public async Task<ActionResult<AnswerDto>> Get(Guid id)
        {
            try
            {
                AnswerDto answer = await _supervisor.GetAnswerByIdAsync(id);
                if (answer == null)
                    return NotFound();
                return Ok(answer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("question/{id}")]
        [Produces(typeof(List<AdministrationDto>))]
        public async Task<ActionResult<List<AdministrationDto>>> GetByQuestion(Guid id)
        {
            try
            {
                QuestionDto question = await _supervisor.GetQuestionByIdAsync(id);
                if (question == null)
                    return NotFound();
                return Ok(await _supervisor.GetAnswerByQuestionIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(AnswerDto))]
        public async Task<ActionResult<AnswerDto>> Post([FromBody] AnswerDto item)
        {
            try
            {
                if (item == null)
                    return BadRequest();
                return Ok(await _supervisor.CreateAnswerAsync(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Produces(typeof(AnswerDto))]
        public async Task<ActionResult<AnswerDto>> Put([FromBody] AnswerDto item)
        {
            try
            {
                if (item == null || item.Id == null)
                    return BadRequest();
                if (await _supervisor.UpdateAnswerAsync(item))
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
                if (await _supervisor.DeleteAnswerAsync(id))
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
