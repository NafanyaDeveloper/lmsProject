using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DATA.Dto
{
    public class DirectionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public string LoadImg { get; set; }
        public List<CourseDto> Courses { get; set; } = new List<CourseDto>();
        public List<AdministrationDto> Administration { get; set; } = new List<AdministrationDto>();
    }
}
