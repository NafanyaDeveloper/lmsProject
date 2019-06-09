using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.DATA.Entities
{
    public class Group
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Participant> Participant { get; set; } = new List<Participant>();
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime Finish { get; set; }
        [Required]
        public Guid CourseId { get; set; }
    }
}
