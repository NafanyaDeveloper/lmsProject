using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DATA.Dto
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid BlockId { get; set; }
        public string BlockName { get; set; }
        public List<AnswerDto> Answers { get; set; } = new List<AnswerDto>();
    }
}
