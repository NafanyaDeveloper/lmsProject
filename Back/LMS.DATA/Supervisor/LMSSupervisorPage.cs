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
        public async Task<List<PageDto>> GetAllPageAsync()
        {
            return PageConverter.Convert(await _pageRepo.GetAllAsync());
        }
        
        public async Task<PageDto> GetPageByIdAsync(Guid id)
        {
            PageDto page = PageConverter.Convert(await _pageRepo.GetByIdAsync(id));
            page.Blocks = BlockConverter.Convert(await _blockRepo.GetByPageIdAsync(id));
            page.CourseName = _courseRepo.GetByIdAsync(page.CourseId).Result.Name;
            return page;
        }

        public async Task<List<PageDto>> GetPageByCourseIdAsync(Guid id)
        {
            return PageConverter.Convert(await _pageRepo.GetByCourseIdAsync(id));
        }

        public async Task<PageDto> CreatePageAsync(PageDto item)
        {
            return PageConverter.Convert(await _pageRepo.CreateAsync(PageConverter.Convert(item)));
        }

        public async Task<bool> UpdatePageAsync(PageDto item)
        {
            return await _pageRepo.UpdateAsync(PageConverter.Convert(item));
        }

        public async Task<bool> DeletePageAsync(Guid id)
        {
            return await _pageRepo.DeleteAsync(id);
        }
    }
}
