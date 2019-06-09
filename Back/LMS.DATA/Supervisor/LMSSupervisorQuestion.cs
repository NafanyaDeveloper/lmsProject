using LMS.DATA.Converters;
using LMS.DATA.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Supervisor
{
    public partial class LMSSupervisor
    {
        public async Task<List<QuestionDto>> GetAllQuestionAsync()
        {
            return QuestionConverter.Convert(await _questionRepo.GetAllAsync());
        }

        public async Task<QuestionDto> GetQuestionByIdAsync(Guid id)
        {
            QuestionDto question = QuestionConverter.Convert(await _questionRepo.GetByIdAsync(id));
            question.Answers = AnswerConverter.Convert(await _answerRepo.GetByQuestionIdAsync(id));
            question.BlockName = _blockRepo.GetByIdAsync(question.BlockId).Result.Name;
            return question;
        }

        public async Task<List<QuestionDto>> GetQuestionByBlockIdAsync(Guid id)
        {
            return QuestionConverter.Convert(await _questionRepo.GetByBlockIdAsync(id));
        }

        public async Task<QuestionDto> CreateQuestionAsync(QuestionDto item)
        {
            return QuestionConverter.Convert(await _questionRepo.CreateAsync(QuestionConverter.Convert(item)));
        }

        public async Task<bool> UpdateQuestionAsync(QuestionDto item)
        {
            return await _questionRepo.UpdateAsync(QuestionConverter.Convert(item));
        }

        public async Task<bool> DeleteQuestionAsync(Guid id)
        {
            return await _questionRepo.DeleteAsync(id);
        }
    }
}
