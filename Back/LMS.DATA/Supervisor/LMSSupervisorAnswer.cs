using LMS.DATA.Converters;
using LMS.DATA.Dto;
using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Supervisor
{
    public partial class LMSSupervisor
    {
        public async Task<List<AnswerDto>> GetAllAnswerAsync()
        {
            return AnswerConverter.Convert(await _answerRepo.GetAllAsync());
        }

        public async Task<AnswerDto> GetAnswerByIdAsync(Guid id)
        {
            AnswerDto answer = AnswerConverter.Convert(await _answerRepo.GetByIdAsync(id));
            answer.QuestionName = _questionRepo.GetByIdAsync(answer.QuestionId).Result.Text;
            return answer;
        }

        public async Task<List<AnswerDto>> GetAnswerByQuestionIdAsync(Guid id)
        {
            return AnswerConverter.Convert(await _answerRepo.GetByQuestionIdAsync(id));
        }

        public async Task<AnswerDto> CreateAnswerAsync(AnswerDto item)
        {
            return AnswerConverter.Convert(await _answerRepo.CreateAsync(AnswerConverter.Convert(item)));
        }

        public async Task<bool> UpdateAnswerAsync(AnswerDto item)
        {
            return await _answerRepo.UpdateAsync(AnswerConverter.Convert(item));
        }

        public async Task<bool> DeleteAnswerAsync(Guid id)
        {
            return await _answerRepo.DeleteAsync(id);
        }
    }
}
