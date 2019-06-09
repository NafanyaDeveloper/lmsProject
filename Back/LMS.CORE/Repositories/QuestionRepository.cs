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
    public class QuestionRepository : IQuestionRepository
    {
        public void Dispose() { }

        private readonly LMSContext _context;


        public QuestionRepository(LMSContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task<Question> CreateAsync(Question item)
        {
            var result = await _context.Questions.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Question question = await GetByIdAsync(id);
            if (question == null)
                return false;
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Question>> GetAllAsync()
        {
            return await _context.Questions.AsNoTracking().ToListAsync();
        }

        public async Task<List<Question>> GetByBlockIdAsync(Guid id)
        {
            return await _context.Questions.AsNoTracking().Where(x => x.BlockId == id).ToListAsync();
        }

        public async Task<Question> GetByIdAsync(Guid id)
        {
            return await _context.Questions.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Question item)
        {
            Question question = await GetByIdAsync(item.Id);
            if (question == null)
                return false;
            _context.Questions.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
