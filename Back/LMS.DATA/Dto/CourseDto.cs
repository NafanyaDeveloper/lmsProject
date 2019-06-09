using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DATA.Dto
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public string LoadImg { get; set; }
        public List<PageDto> Pages { get; set; } = new List<PageDto>();
        public List<GroupDto> Groups { get; set; } = new List<GroupDto>();
        public Guid DirectionId { get; set; }
        public string DirectionName { get; set; }
    }
}
