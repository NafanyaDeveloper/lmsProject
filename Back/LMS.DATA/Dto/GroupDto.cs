using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DATA.Dto
{
    public class GroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ParticipantDto> Participant { get; set; } = new List<ParticipantDto>();
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
