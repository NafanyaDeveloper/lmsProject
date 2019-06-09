using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.DATA.Entities
{
    public class Page
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public double Number { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsMilestone { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        public List<Block> Blocks { get; set; } = new List<Block>();
    }
}
