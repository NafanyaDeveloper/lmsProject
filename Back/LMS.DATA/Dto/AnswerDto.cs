using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DATA.Dto
{
    public class AnswerDto
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public Guid QuestionId { get; set; }
        public string QuestionName { get; set; }
    }
}
