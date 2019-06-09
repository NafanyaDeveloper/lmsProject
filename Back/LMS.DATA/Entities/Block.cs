using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.DATA.Entities
{
    public class Block
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid BlockTypeId { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public string Text { get; set; }
        public string Img { get; set; }
        [NotMapped]
        public string LoadImg { get; set; }
        [Required]
        public Guid PageId { get; set; }
    }
}
