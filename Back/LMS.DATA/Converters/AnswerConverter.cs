using LMS.DATA.Dto;
using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DATA.Converters
{
    public static class AnswerConverter
    {
        public static AnswerDto Convert(Answer item)
        {
            return new AnswerDto
            {
                Id = item.Id,
                QuestionId = item.QuestionId,
                Value = item.Value
            };
        }

        public static Answer Convert(AnswerDto item)
        {
            return new Answer
            {
                Id = item.Id,
                QuestionId = item.QuestionId,
                Value = item.Value
            };
        }

        public static List<Answer> Convert(List<AnswerDto> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }

        public static List<AnswerDto> Convert(List<Answer> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }
    }
}
