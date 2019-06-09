using LMS.CORE.EF;
using LMS.DATA.Entities;
using LMS.DATA.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.CORE.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        public void Dispose() { }

        private readonly LMSContext _context;


        public AnswerRepository(LMSContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task<Answer> CreateAsync(Answer item)
        {
            var result = await _context.Answers.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Answer answer = await GetByIdAsync(id);
            if (answer == null)
                return false;
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Answer>> GetAllAsync()
        {
            return await _context.Answers.AsNoTracking().ToListAsync();
        }

        public async Task<Answer> GetByIdAsync(Guid id)
        {
            return await _context.Answers.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<List<Answer>> GetByQuestionIdAsync(Guid id)
        {
            return await _context.Answers.AsNoTracking().Where(x => x.QuestionId == id).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Answer item)
        {
            Answer answer = await GetByIdAsync(item.Id);
            if (answer == null)
                return false;
            _context.Answers.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
