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
            CreateMap<Billing, BillingDTO>().ReverseMap();
            CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            CreateMap<Trainer,TrainerDTO>().ReverseMap();
            CreateMap<Member, MemberDTO>().ReverseMap();
            CreateMap<ClassRegistration, ClassRegistrationDTO>().ReverseMap();
            CreateMap<Equipment, EquipmentDTO>().ReverseMap();
        }
    }
}
