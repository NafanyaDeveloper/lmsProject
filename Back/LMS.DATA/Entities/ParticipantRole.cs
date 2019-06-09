using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.DATA.Entities
{
    public class ParticipantRole
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Participant> Participants { get; set; } = new List<Participant>();
    }
}
