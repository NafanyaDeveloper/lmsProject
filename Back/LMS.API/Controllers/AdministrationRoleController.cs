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
    public class AdministrationRoleController: Controller
    {
        private readonly ILMSSupervisor _supervisor;

        public AdministrationRoleController(ILMSSupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        [HttpGet]
        [Produces(typeof(List<AdministrationRole>))]
        public async Task<ActionResult<List<AdministrationRole>>> Get()
        {
            try
            {
                return Ok(await _supervisor.GetAllAdministrationRoleAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(AdministrationRole))]
        public async Task<ActionResult<AdministrationRole>> Get(Guid id)
        {
            try
            {
                AdministrationRole aRole = await _supervisor.GetAdministrationRoleByIdAsync(id);
                if (aRole == null)
                    return NotFound();
                return Ok(aRole);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces(typeof(AdministrationRole))]
        public async Task<ActionResult<AdministrationRole>> Post([FromBody] AdministrationRole item)
        {
            try
            {
                if (item == null)
                    return BadRequest();
                return Ok(await _supervisor.CreateAdministrationRoleAsync(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Produces(typeof(AdministrationRole))]
        public async Task<ActionResult<AdministrationRole>> Put([FromBody] AdministrationRole item)
        {
            try
            {
                if (item == null || item.Id == null)
                    return BadRequest();
                if (await _supervisor.UpdateAdministrationRoleAsync(item))
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
                if (await _supervisor.DeleteAdministrationRoleAsync(id))
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
