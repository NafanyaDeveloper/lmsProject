using LMS.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DATA.Supervisor
{
    public partial class LMSSupervisor : ILMSSupervisor
    {
        private readonly IAdministrationRepository _adminRepo;
        private readonly IAdministrationRoleRepository _adminRoleRepo;
        private readonly IAnswerRepository _answerRepo;
        private readonly IBlockRepository _blockRepo;
        private readonly IBlockTypeRepository _blockTypeRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly IDirectionRepository _directionRepo;
        private readonly IGroupRepository _groupRepo;
        private readonly IPageRepository _pageRepo;
        private readonly IParticipantRepository _participantRepo;
        private readonly IParticipantRoleRepository _participantRoleRepo;
        private readonly IQuestionRepository _questionRepo;
        private readonly IUserRepository _userRepo;

        public LMSSupervisor() { }

        public LMSSupervisor(
            IAdministrationRepository adminRepo, 
            IAdministrationRoleRepository adminRoleRepo,
            IAnswerRepository answerRepo,
            IBlockRepository blockRepo,
            IBlockTypeRepository blockTypeRepo,
            ICourseRepository courseRepo,
            IDirectionRepository directionRepo,
            IGroupRepository groupRepo,
            IPageRepository pageRepo,
            IParticipantRepository participantRepo,
            IParticipantRoleRepository participantRoleRepo,
            IQuestionRepository questionRepo,
            IUserRepository userRepo)
        {
            _adminRepo = adminRepo;
            _adminRoleRepo = adminRoleRepo;
            _answerRepo = answerRepo;
            _blockRepo = blockRepo;
            _blockTypeRepo = blockTypeRepo;
            _courseRepo = courseRepo;
            _directionRepo = directionRepo;
            _groupRepo = groupRepo;
            _pageRepo = pageRepo;
            _participantRepo = participantRepo;
            _participantRoleRepo = participantRoleRepo;
            _questionRepo = questionRepo;
            _userRepo = userRepo;
        }
    }
}
