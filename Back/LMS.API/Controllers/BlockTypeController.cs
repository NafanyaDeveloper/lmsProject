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
    public class BlockTypeController: Controller
    {
        private readonly ILMSSupervisor _supervisor;

        public BlockTypeController(ILMSSupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        [HttpGet]
        [Produces(typeof(List<BlockType>))]
        public async Task<ActionResult<List<BlockType>>> Get()
        {
            try
            {
                return Ok(await _supervisor.GetAllBlockTypeAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(BlockType))]
        public async Task<ActionResult<BlockType>> Get(Guid id)
        {
            try
            {
                BlockType bType = await _supervisor.GetBlockTypeByIdAsync(id);
                if (bType == null)
                    return NotFound();
                return Ok(bType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(BlockType))]
        public async Task<ActionResult<BlockType>> Post([FromBody] BlockType item)
        {
            try
            {
                if (item == null)
                    return BadRequest();
                return Ok(await _supervisor.CreateBlockTypeAsync(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Produces(typeof(BlockType))]
        public async Task<ActionResult<BlockType>> Put([FromBody] BlockType item)
        {
            try
            {
                if (item == null || item.Id == null)
                    return BadRequest();
                if (await _supervisor.UpdateBlockTypeAsync(item))
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
                if (await _supervisor.DeleteBlockTypeAsync(id))
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
