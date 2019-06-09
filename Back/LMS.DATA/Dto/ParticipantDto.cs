using LMS.DATA.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DATA.Dto
{
    public class ParticipantDto
    {
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
        public Guid ParticipantRoleId { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string GroupName { get; set; }
    }
}
