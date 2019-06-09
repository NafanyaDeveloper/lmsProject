using LMS.DATA.Converters;
using LMS.DATA.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Supervisor
{
    public partial class LMSSupervisor
    {
        public async Task<List<DirectionDto>> GetAllDirectionAsync()
        {
            List<DirectionDto> directions = DirectionConverter.Convert(await _directionRepo.GetAllAsync());
            List<CourseDto> courses = await GetAllCourseAsync();
            foreach (DirectionDto i in directions)
                i.Courses = courses.Where(x => x.DirectionId == i.Id).ToList();
            return directions;
        }

        public async Task<DirectionDto> GetDirectionByIdAsync(Guid id)
        {
            DirectionDto direction = DirectionConverter.Convert(await _directionRepo.GetByIdAsync(id));
            direction.Administration = AdministrationConverter.Convert(await _adminRepo.GetByDirectionIdAsync(id));
            direction.Courses = CourseConverter.Convert(await _courseRepo.GetByDirectionIdAsync(id));
            return direction;
        }

        public async Task<DirectionDto> CreateDirectionAsync(DirectionDto item)
        {
            return DirectionConverter.Convert(await _directionRepo.CreateAsync(DirectionConverter.Convert(item)));
        }

        public async Task<bool> UpdateDirectionAsync(DirectionDto item)
        {
            return await _directionRepo.UpdateAsync(DirectionConverter.Convert(item));
        }

        public async Task<bool> DeleteDirectionAsync(Guid id)
        {
            return await _directionRepo.DeleteAsync(id);
        }
    }
}
