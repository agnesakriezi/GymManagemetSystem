using GymManagementSystem.DTOs;
using GymManagementSystem.Models;
using GymManagementSystem.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMapper _mapper;

        public MembershipService(IMembershipRepository membershipRepository, IMapper mapper)
        {
            _membershipRepository = membershipRepository;
            _mapper = mapper;
        }

        public async Task<MembershipDTO> GetMembershipByIdAsync(int id)
        {
            var membership = await _membershipRepository.GetMembershipByIdAsync(id);
            return _mapper.Map<MembershipDTO>(membership);
        }

        public async Task<IEnumerable<MembershipDTO>> GetAllMembershipsAsync()
        {
            var memberships = await _membershipRepository.GetAllMembershipsAsync();
            return _mapper.Map<IEnumerable<MembershipDTO>>(memberships);
        }

        public async Task<MembershipDTO> AddMembershipAsync(MembershipDTO membershipDto)
        {
            var membership = _mapper.Map<Membership>(membershipDto);
            await _membershipRepository.AddMembershipAsync(membership);
            return _mapper.Map<MembershipDTO>(membership);
        }

        public async Task<MembershipDTO> UpdateMembershipAsync(int id, MembershipDTO membershipDto)
        {
            var membership = await _membershipRepository.GetMembershipByIdAsync(id);
            if (membership == null)
            {
                return null;
            }

            // Do not map the ID to avoid modifying it
            membership.MemberName = membershipDto.MemberName;
            membership.StartDate = membershipDto.StartDate;
            membership.EndDate = membershipDto.EndDate;
            membership.Type = membershipDto.Type;

            await _membershipRepository.UpdateMembershipAsync(membership);
            return _mapper.Map<MembershipDTO>(membership);
        }

        public async Task DeleteMembershipAsync(int id)
        {
            var membership = await _membershipRepository.GetMembershipByIdAsync(id);
            if (membership != null)
            {
                await _membershipRepository.DeleteMembershipAsync(membership);
            }
        }
    }
}
