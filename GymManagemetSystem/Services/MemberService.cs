using AutoMapper;
using GymManagementSystem.DTOs;
using GymManagementSystem.Models;
using GymManagementSystem.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MemberDTO>> GetAllAsync()
        {
            var members = await _memberRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MemberDTO>>(members);
        }

        public async Task<MemberDTO> GetByIdAsync(int id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            return _mapper.Map<MemberDTO>(member);
        }

        public async Task AddAsync(MemberDTO memberDto)
        {
            var member = _mapper.Map<Member>(memberDto);
            await _memberRepository.AddAsync(member);
        }

        public async Task UpdateAsync(MemberDTO memberDto)
        {
            var member = _mapper.Map<Member>(memberDto);
            await _memberRepository.UpdateAsync(member);
        }

        public async Task DeleteAsync(int id)
        {
            await _memberRepository.DeleteAsync(id);
        }
    }
}
