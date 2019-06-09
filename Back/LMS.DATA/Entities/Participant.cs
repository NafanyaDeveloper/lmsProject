using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.DATA.Entities
{
    public class Participant
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid GroupId { get; set; }
        [Required]
        public Guid ParticipantRoleId { get; set; }
    }
}
