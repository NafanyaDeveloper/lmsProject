using LMS.DATA.Dto;
using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DATA.Converters
{
    public static class CourseConverter
    {
        public static CourseDto Convert(Course item)
        {
            return new CourseDto
            {
                Description = item.Description,
                DirectionId = item.DirectionId,
                Id = item.Id,
                Img = item.Img,
                LoadImg = item.LoadImg,
                Name = item.Name
            };
        }

        public static Course Convert(CourseDto item)
        {
            return new Course
            {
                Description = item.Description,
                DirectionId = item.DirectionId,
                Id = item.Id,
                Img = item.Img,
                LoadImg = item.LoadImg,
                Name = item.Name
            };
        }

        public static List<Course> Convert(List<CourseDto> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }

        public static List<CourseDto> Convert(List<Course> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }
    }
}
