using LMS.DATA.Dto;
using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Supervisor
{
    public interface ILMSSupervisor
    {
        Task<List<AdministrationDto>> GetAllAdministrationAsync();

        Task<AdministrationDto> GetAdministrationByIdAsync(Guid userId, Guid directionId);

        Task<List<AdministrationDto>> GetAdministrationByDirectionIdAsync(Guid id);

        Task<List<AdministrationDto>> GetAdministrationByUserIdAsync(Guid id);

        Task<List<AdministrationDto>> GetAdministrationByRoleIdAsync(Guid id);

        Task<AdministrationDto> CreateAdministrationAsync(AdministrationDto item);

        Task<bool> UpdateAdministrationAsync(AdministrationDto item);

        Task<bool> DeleteAdministrationAsync(Guid userId, Guid directionId);

        Task<List<AdministrationRole>> GetAllAdministrationRoleAsync();

        Task<AdministrationRole> GetAdministrationRoleByIdAsync(Guid id);

        Task<AdministrationRole> CreateAdministrationRoleAsync(AdministrationRole item);

        Task<bool> UpdateAdministrationRoleAsync(AdministrationRole item);

        Task<bool> DeleteAdministrationRoleAsync(Guid id);

        Task<List<AnswerDto>> GetAllAnswerAsync();

        Task<AnswerDto> GetAnswerByIdAsync(Guid id);

        Task<List<AnswerDto>> GetAnswerByQuestionIdAsync(Guid id);

        Task<AnswerDto> CreateAnswerAsync(AnswerDto item);

        Task<bool> UpdateAnswerAsync(AnswerDto item);

        Task<bool> DeleteAnswerAsync(Guid id);

        Task<List<BlockDto>> GetAllBlockAsync();

        Task<BlockDto> GetBlockByIdAsync(Guid id);

        Task<List<BlockDto>> GetBlockByPageIdAsync(Guid id);

        Task<List<BlockDto>> GetBlockByBlockTypeIdAsync(Guid id);

        Task<BlockDto> CreateBlockAsync(BlockDto item);

        Task<bool> UpdateBlockAsync(BlockDto item);

        Task<bool> DeleteBlockAsync(Guid id);

        Task<List<BlockType>> GetAllBlockTypeAsync();

        Task<BlockType> GetBlockTypeByIdAsync(Guid id);

        Task<BlockType> CreateBlockTypeAsync(BlockType item);

        Task<bool> UpdateBlockTypeAsync(BlockType item);

        Task<bool> DeleteBlockTypeAsync(Guid id);

        Task<List<CourseDto>> GetAllCourseAsync();

        Task<CourseDto> GetCourseByIdAsync(Guid id);

        Task<List<CourseDto>> GetCourseByDirectionIdAsync(Guid id);

        Task<CourseDto> CreateCourseAsync(CourseDto item);

        Task<bool> UpdateCourseAsync(CourseDto item);

        Task<bool> DeleteCourseAsync(Guid id);

        Task<List<DirectionDto>> GetAllDirectionAsync();

        Task<DirectionDto> GetDirectionByIdAsync(Guid id);

        Task<DirectionDto> CreateDirectionAsync(DirectionDto item);

        Task<bool> UpdateDirectionAsync(DirectionDto item);

        Task<bool> DeleteDirectionAsync(Guid id);

        Task<List<GroupDto>> GetAllGroupAsync();

        Task<GroupDto> GetGroupByIdAsync(Guid id);

        Task<List<GroupDto>> GetGroupByCourseIdAsync(Guid id);

        Task<GroupDto> CreateGroupAsync(GroupDto item);

        Task<bool> UpdateGroupAsync(GroupDto item);

        Task<bool> DeleteGroupAsync(Guid id);

        Task<List<PageDto>> GetAllPageAsync();

        Task<PageDto> GetPageByIdAsync(Guid id);

        Task<List<PageDto>> GetPageByCourseIdAsync(Guid id);

        Task<PageDto> CreatePageAsync(PageDto item);

        Task<bool> UpdatePageAsync(PageDto item);

        Task<bool> DeletePageAsync(Guid id);

        Task<List<ParticipantDto>> GetAllParticipantAsync();

        Task<ParticipantDto> GetParticipantByIdAsync(Guid userId, Guid groupId);

        Task<List<ParticipantDto>> GetParticipantByGroupIdAsync(Guid id);

        Task<List<ParticipantDto>> GetParticipantByUserIdAsync(Guid id);

        Task<List<ParticipantDto>> GetParticipantByRoleIdAsync(Guid id);

        Task<ParticipantDto> CreateParticipantAsync(ParticipantDto item);

        Task<bool> UpdateParticipantAsync(ParticipantDto item);

        Task<bool> DeleteParticipantAsync(Guid userId, Guid groupId);

        Task<List<ParticipantRole>> GetAllParticipantRoleAsync();

        Task<ParticipantRole> GetParticipantRoleByIdAsync(Guid id);

        Task<ParticipantRole> CreateParticipantRoleAsync(ParticipantRole item);

        Task<bool> UpdateParticipantRoleAsync(ParticipantRole item);

        Task<bool> DeleteParticipantRoleAsync(Guid id);

        Task<List<QuestionDto>> GetAllQuestionAsync();

        Task<QuestionDto> GetQuestionByIdAsync(Guid id);

        Task<List<QuestionDto>> GetQuestionByBlockIdAsync(Guid id);

        Task<QuestionDto> CreateQuestionAsync(QuestionDto item);

        Task<bool> UpdateQuestionAsync(QuestionDto item);

        Task<bool> DeleteQuestionAsync(Guid id);

        Task<List<UserDto>> GetAllUserAsync();

        Task<UserDto> GetUserByIdAsync(Guid id);

        Task<UserDto> CreateUserAsync(UserDto item);

        Task<bool> UpdateUserAsync(UserDto item);

        Task<bool> DeleteUserAsync(Guid id);
    }
}
