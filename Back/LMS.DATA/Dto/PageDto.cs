using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DATA.Dto
{
    public class PageDto
    {
        public Guid Id { get; set; }
        public double Number { get; set; }
        public string Name { get; set; }
        public bool IsMilestone { get; set; }
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public List<BlockDto> Blocks { get; set; } = new List<BlockDto>();
    }
}
