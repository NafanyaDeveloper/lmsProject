using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.DATA.Entities
{
    public class Course
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
        public List<Page> Pages { get; set; } = new List<Page>();
        public List<Group> Groups { get; set; } = new List<Group>();
        [Required]
        public Guid DirectionId { get; set; }
    }
}
