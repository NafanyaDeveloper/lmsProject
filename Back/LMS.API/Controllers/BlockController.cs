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
    public class BlockController: Controller
    {
        private readonly ILMSSupervisor _supervisor;

        public BlockController(ILMSSupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        [HttpGet]
        [Produces(typeof(List<BlockDto>))]
        public async Task<ActionResult<List<BlockDto>>> Get()
        {
            try
            {
                return Ok(await _supervisor.GetAllBlockAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(BlockDto))]
        public async Task<ActionResult<BlockDto>> Get(Guid id)
        {
            try
            {
                BlockDto Block = await _supervisor.GetBlockByIdAsync(id);
                if (Block == null)
                    return NotFound();
                return Ok(Block);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("page/{id}")]
        [Produces(typeof(List<AdministrationDto>))]
        public async Task<ActionResult<List<AdministrationDto>>> GetByPage(Guid id)
        {
            try
            {
                PageDto page = await _supervisor.GetPageByIdAsync(id);
                if (page == null)
                    return NotFound();
                return Ok(await _supervisor.GetBlockByPageIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("type/{id}")]
        [Produces(typeof(List<AdministrationDto>))]
        public async Task<ActionResult<List<AdministrationDto>>> GetByBlockType(Guid id)
        {
            try
            {
                BlockType blockType = await _supervisor.GetBlockTypeByIdAsync(id);
                if (blockType == null)
                    return NotFound();
                return Ok(await _supervisor.GetBlockByBlockTypeIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(BlockDto))]
        public async Task<ActionResult<BlockDto>> Post([FromBody] BlockDto item)
        {
            try
            {
                if (item == null)
                    return BadRequest();
                return Ok(await _supervisor.CreateBlockAsync(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Produces(typeof(BlockDto))]
        public async Task<ActionResult<BlockDto>> Put([FromBody] BlockDto item)
        {
            try
            {
                if (item == null || item.Id == null)
                    return BadRequest();
                if (await _supervisor.UpdateBlockAsync(item))
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
                if (await _supervisor.DeleteBlockAsync(id))
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
