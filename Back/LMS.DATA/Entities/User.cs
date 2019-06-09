using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.DATA.Entities
{
    public class User: IdentityUser<Guid>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Avatar { get; set; } = "/avatar/default.jpg";
        [NotMapped]
        public string LoadImg { get; set; }
        [Required]
        public DateTime Birth { get; set; }
        [NotMapped]
        public string FullName { get; }  
        public List<Participant> Participant { get; set; } = new List<Participant>();
        public List<Administration> Administration { get; set; } = new List<Administration>();
    }
}
