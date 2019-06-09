using LMS.DATA.Dto;
using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DATA.Converters
{
    public static class DirectionConverter
    {
        public static DirectionDto Convert(Direction item)
        {
            return new DirectionDto
            {
                Id = item.Id,
                Description = item.Description,
                Name = item.Name,
                Img = item.Img,
                LoadImg = item.LoadImg
            };
        }

        public static Direction Convert(DirectionDto item)
        {
            return new Direction
            {
                Id = item.Id,
                Description = item.Description,
                Name = item.Name,
                Img = item.Img,
                LoadImg = item.LoadImg
            };
        }

        public static List<DirectionDto> Convert(List<Direction> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }

        public static List<Direction> Convert(List<DirectionDto> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }
    }
}
