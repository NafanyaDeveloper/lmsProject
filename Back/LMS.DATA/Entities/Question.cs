using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.DATA.Entities
{
    public class Question
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public Guid BlockId { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
