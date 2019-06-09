using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.DATA.Entities
{
    public class BlockType
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Block> Blocks { get; set; } = new List<Block>();
    }
}
