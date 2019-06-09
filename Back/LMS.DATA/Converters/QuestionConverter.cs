using LMS.DATA.Dto;
using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DATA.Converters
{
    public static class QuestionConverter
    {
        public static QuestionDto Convert(Question item)
        {
            return new QuestionDto
            {
                BlockId = item.BlockId,
                Id = item.Id,
                Text = item.Text
            };
        }

        public static Question Convert(QuestionDto item)
        {
            return new Question
            {
                BlockId = item.BlockId,
                Id = item.Id,
                Text = item.Text
            };
        }

        public static List<Question> Convert(List<QuestionDto> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }

        public static List<QuestionDto> Convert(List<Question> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }
    }
}
