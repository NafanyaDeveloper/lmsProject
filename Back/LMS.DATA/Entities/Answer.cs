using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.DATA.Entities
{
    public class Answer
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public Guid QuestionId { get; set; }
    }
}
