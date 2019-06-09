using LMS.DATA.Dto;
using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DATA.Converters
{
    public static class PageConverter
    {
        public static PageDto Convert(Page item)
        {
            return new PageDto
            {
                CourseId = item.CourseId,
                Id = item.Id,
                IsMilestone = item.IsMilestone,
                Name = item.Name,
                Number = item.Number
            };
        }

        public static Page Convert(PageDto item)
        {
            return new Page
            {
                CourseId = item.CourseId,
                Id = item.Id,
                IsMilestone = item.IsMilestone,
                Name = item.Name,
                Number = item.Number
            };
        }

        public static List<Page> Convert(List<PageDto> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }

        public static List<PageDto> Convert(List<Page> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }
    }
}
