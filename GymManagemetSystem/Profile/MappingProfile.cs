using AutoMapper;
using GymManagementSystem.DTOs;
using GymManagementSystem.Models;

namespace GymManagementSystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Membership, MembershipDTO>().ReverseMap();
            CreateMap<Attendance, AttendanceDTO>().ReverseMap();
        }
    }
}
