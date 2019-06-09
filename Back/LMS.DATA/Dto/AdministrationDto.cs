using LMS.DATA.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DATA.Dto
{
    public class AdministrationDto
    {
        public Guid UserId { get; set; }
        public Guid DirectionId { get; set; }
        public Guid AdministrationRoleId { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string DirectionName { get; set; }
    }
}
