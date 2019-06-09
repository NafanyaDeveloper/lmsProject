using LMS.DATA.Dto;
using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.DATA.Converters
{
    public static class ParticipantConverter
    {
        public static ParticipantDto Convert(Participant item)
        {
            return new ParticipantDto
            {
                GroupId = item.GroupId,
                ParticipantRoleId = item.ParticipantRoleId,
                UserId = item.UserId
            };
        }

        public static Participant Convert(ParticipantDto item)
        {
            return new Participant
            {
                GroupId = item.GroupId,
                ParticipantRoleId = item.ParticipantRoleId,
                UserId = item.UserId
            };
        }

        public static List<Participant> Convert(List<ParticipantDto> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }

        public static List<ParticipantDto> Convert(List<Participant> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }
    }
}
