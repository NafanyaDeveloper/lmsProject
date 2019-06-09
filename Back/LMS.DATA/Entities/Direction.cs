using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.DATA.Entities
{
    public class Direction
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Img { get; set; }
        [NotMapped]
        public string LoadImg { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Administration> Administration { get; set; } = new List<Administration>();
    }
}
