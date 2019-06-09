using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DATA.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; } = "/avatar/default.jpg";
        public string LoadImg { get; set; }
        public DateTime Birth { get; set; }
        public string Password { get; set; }
        public List<ParticipantDto> Participant { get; set; } = new List<ParticipantDto>();
        public List<AdministrationDto> Administration { get; set; } = new List<AdministrationDto>();

        public UserDto()
        {
            FullName = $"{Surname} {Name}";
        }
    }
}
