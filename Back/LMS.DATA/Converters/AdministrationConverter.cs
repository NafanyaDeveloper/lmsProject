using LMS.DATA.Dto;
using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DATA.Converters
{
    public static class AdministrationConverter
    {
        public static AdministrationDto Convert(Administration item)
        {
            return new AdministrationDto
            {
                AdministrationRoleId = item.AdministrationRoleId,
                DirectionId = item.DirectionId,
                UserId = item.UserId
            };
        }

        public static Administration Convert(AdministrationDto item)
        {
            return new Administration
            {
                AdministrationRoleId = item.AdministrationRoleId,
                DirectionId = item.DirectionId,
                UserId = item.UserId
            };
        }

        public static List<Administration> Convert(List<AdministrationDto> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }

        public static List<AdministrationDto> Convert(List<Administration> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }
    }
}
