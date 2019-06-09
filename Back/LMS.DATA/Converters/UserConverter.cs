using LMS.DATA.Dto;
using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DATA.Converters
{
    public static class UserConverter
    {
        public static UserDto Convert(User item)
        {
            return new UserDto
            {
                Id = item.Id,
                Avatar = item.Avatar,
                Surname = item.Surname,
                Birth = item.Birth,
                LoadImg = item.LoadImg,
                Name = item.Name,
                Email = item.Email
            };
        }

        public static User Convert(UserDto item)
        {
            return new User
            {
                Id = item.Id,
                Avatar = item.Avatar,
                Surname = item.Surname,
                Birth = item.Birth,
                LoadImg = item.LoadImg,
                Name = item.Name,
                Email = item.Email,
                UserName = item.Email
            };
        }

        public static void Convert(ref User user, UserDto item)
        {
            user.LoadImg = item.LoadImg;
            user.Avatar = item.Avatar;
            user.Surname = item.Surname;
            user.Birth = item.Birth;
            user.Name = item.Name;
        }

        public static void Convert(ref User user, User item)
        {
            user.Avatar = item.Avatar;
            user.Surname = item.Surname;
            user.Birth = item.Birth;
            user.Name = item.Name;
        }

        public static List<User> Convert(List<UserDto> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }

        public static List<UserDto> Convert(List<User> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }
    }
}
