using GymManagementSystem.DTOs;
using GymManagementSystem.Models;
using GymManagementSystem.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMapper _mapper;

        public AttendanceService(IAttendanceRepository attendanceRepository, IMembershipRepository membershipRepository, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _membershipRepository = membershipRepository;
            _mapper = mapper;
        }

        public async Task<AttendanceDTO> GetAttendanceByIdAsync(int id)
        {
            var attendance = await _attendanceRepository.GetAttendanceByIdAsync(id);
            return _mapper.Map<AttendanceDTO>(attendance);
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAllAttendancesAsync()
        {
            var attendances = await _attendanceRepository.GetAllAttendancesAsync();
            return _mapper.Map<IEnumerable<AttendanceDTO>>(attendances);
        }

        public async Task<AttendanceDTO> AddAttendanceAsync(AttendanceDTO attendanceDto)
        {
            var membership = await _membershipRepository.GetMembershipByIdAsync(attendanceDto.MembershipId);
            if (membership == null)
            {
                return null;
            }

            var attendance = _mapper.Map<Attendance>(attendanceDto);
            await _attendanceRepository.AddAttendanceAsync(attendance);
            return _mapper.Map<AttendanceDTO>(attendance);
        }

        public async Task<AttendanceDTO> UpdateAttendanceAsync(int id, AttendanceDTO attendanceDto)
        {
            var attendance = await _attendanceRepository.GetAttendanceByIdAsync(id);
            if (attendance == null)
            {
                return null;
            }

            var membership = await _membershipRepository.GetMembershipByIdAsync(attendanceDto.MembershipId);
            if (membership == null)
            {
                return null;
            }

            // Update the properties except the Id
            attendance.MembershipId = attendanceDto.MembershipId;
            attendance.Date = attendanceDto.Date;
            attendance.IsPresent = attendanceDto.IsPresent;

            await _attendanceRepository.UpdateAttendanceAsync(attendance);
            return _mapper.Map<AttendanceDTO>(attendance);
        }

        public async Task DeleteAttendanceAsync(int id)
        {
            var attendance = await _attendanceRepository.GetAttendanceByIdAsync(id);
            if (attendance != null)
            {
                await _attendanceRepository.DeleteAttendanceAsync(attendance);
            }
        }
    }
}
