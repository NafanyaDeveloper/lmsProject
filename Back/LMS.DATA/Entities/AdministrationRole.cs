using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.DATA.Entities
{
    public class AdministrationRole
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Administration> Administration { get; set; } = new List<Administration>();
    }
}
