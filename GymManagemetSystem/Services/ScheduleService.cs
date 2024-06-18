using GymManagementSystem.DTOs;
using GymManagementSystem.Models;
using GymManagementSystem.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public async Task<ScheduleDTO> GetScheduleByIdAsync(int id)
        {
            var schedule = await _scheduleRepository.GetScheduleByIdAsync(id);
            return _mapper.Map<ScheduleDTO>(schedule);
        }

        public async Task<IEnumerable<ScheduleDTO>> GetAllSchedulesAsync()
        {
            var schedules = await _scheduleRepository.GetAllSchedulesAsync();
            return _mapper.Map<IEnumerable<ScheduleDTO>>(schedules);
        }

        public async Task<ScheduleDTO> AddScheduleAsync(ScheduleDTO scheduleDto)
        {
            var schedule = _mapper.Map<Schedule>(scheduleDto);

            // Convert to UTC before saving
            schedule.StartTime = DateTime.SpecifyKind(scheduleDto.StartTime, DateTimeKind.Utc);
            schedule.EndTime = DateTime.SpecifyKind(scheduleDto.EndTime, DateTimeKind.Utc);

            await _scheduleRepository.AddScheduleAsync(schedule);
            return _mapper.Map<ScheduleDTO>(schedule);
        }

        public async Task<ScheduleDTO> UpdateScheduleAsync(int id, ScheduleDTO scheduleDto)
        {
            var schedule = await _scheduleRepository.GetScheduleByIdAsync(id);
            if (schedule == null)
            {
                return null;
            }

            // Map DTO to entity and ensure DateTime values are in UTC
            _mapper.Map(scheduleDto, schedule);
            schedule.StartTime = DateTime.SpecifyKind(scheduleDto.StartTime, DateTimeKind.Utc);
            schedule.EndTime = DateTime.SpecifyKind(scheduleDto.EndTime, DateTimeKind.Utc);

            await _scheduleRepository.UpdateScheduleAsync(schedule);
            return _mapper.Map<ScheduleDTO>(schedule);
        }


        public async Task DeleteScheduleAsync(int id)
        {
            var schedule = await _scheduleRepository.GetScheduleByIdAsync(id);
            if (schedule != null)
            {
                await _scheduleRepository.DeleteScheduleAsync(schedule);
            }
        }
    }
}
