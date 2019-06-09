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
        public async Task<List<CourseDto>> GetAllCourseAsync()
        {
            return CourseConverter.Convert(await _courseRepo.GetAllAsync());
        }

        public async Task<CourseDto> GetCourseByIdAsync(Guid id)
        {
            CourseDto course = CourseConverter.Convert(await _courseRepo.GetByIdAsync(id));
            course.DirectionName = _directionRepo.GetByIdAsync(course.DirectionId).Result.Name;
            course.Groups = GroupConverter.Convert(await _groupRepo.GetByCourseIdAsync(id));
            course.Pages = PageConverter.Convert(await _pageRepo.GetByCourseIdAsync(id));
            return course;
        }

        public async Task<List<CourseDto>> GetCourseByDirectionIdAsync(Guid id)
        {
            return CourseConverter.Convert(await _courseRepo.GetByDirectionIdAsync(id));
        }

        public async Task<CourseDto> CreateCourseAsync(CourseDto item)
        {
            return CourseConverter.Convert(await _courseRepo.CreateAsync(CourseConverter.Convert(item)));
        }

        public async Task<bool> UpdateCourseAsync(CourseDto item)
        {
            return await _courseRepo.UpdateAsync(CourseConverter.Convert(item));
        }

        public async Task<bool> DeleteCourseAsync(Guid id)
        {
            return await _courseRepo.DeleteAsync(id);
        }
    }
}
