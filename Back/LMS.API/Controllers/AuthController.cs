using LMS.API.ViewModels;
using LMS.AUTH.Interfaces;
using LMS.DATA.Converters;
using LMS.DATA.Dto;
using LMS.DATA.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[action]")]
    public class AuthController: Controller
    {
        private readonly IAuthService _auth;


        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost]
        [AllowAnonymous]
        [Produces(typeof(object))]
        public async Task<ActionResult<object>> Login([FromBody] LoginViewModel form)
        {
            try
            {
                var result = await _auth.Login(form.Email, form.Password);
                if (result == null)
                    return BadRequest();
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Produces(typeof(object))]
        public async Task<ActionResult<object>> Register([FromBody] UserDto item)
        {
            try
            {
                var result = await _auth.Register(item);
                if (result == null)
                    return BadRequest();
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}
