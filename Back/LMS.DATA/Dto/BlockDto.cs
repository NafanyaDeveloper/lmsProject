using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DATA.Dto
{
    public class BlockDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BlockTypeId { get; set; }
        public List<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
        public string Text { get; set; }
        public string Img { get; set; }
        public string LoadImg { get; set; }
        public Guid PageId { get; set; }
        public string PageName { get; set; }
        public string BlockTypeName { get; set; }
    }
}
