using LMS.DATA.Dto;
using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DATA.Converters
{
    public static class GroupConverter
    {
        public static GroupDto Convert(Group item)
        {
            return new GroupDto
            {
                CourseId = item.CourseId,
                Finish = item.Finish,
                Id = item.Id,
                Name = item.Name,
                Start = item.Start
            };
        }

        public static Group Convert(GroupDto item)
        {
            return new Group
            {
                CourseId = item.CourseId,
                Finish = item.Finish,
                Id = item.Id,
                Name = item.Name,
                Start = item.Start
            };
        }

        public static List<Group> Convert(List<GroupDto> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }

        public static List<GroupDto> Convert(List<Group> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }
    }
}
