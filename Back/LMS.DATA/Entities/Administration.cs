using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.DATA.Entities
{
    public class Administration
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid DirectionId { get; set; }
        [Required]
        public Guid AdministrationRoleId { get; set; }
    }
}
