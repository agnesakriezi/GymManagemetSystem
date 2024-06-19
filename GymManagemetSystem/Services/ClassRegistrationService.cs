using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagementSystem.DTOs;
using GymManagementSystem.Models;
using GymManagementSystem.Repositories;
using AutoMapper;

namespace GymManagementSystem.Services
{
    public class ClassRegistrationService : IClassRegistrationService
    {
        private readonly IClassRegistrationRepository _classRegistrationRepository;
        private readonly IMapper _mapper;

        public ClassRegistrationService(IClassRegistrationRepository classRegistrationRepository, IMapper mapper)
        {
            _classRegistrationRepository = classRegistrationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassRegistrationDTO>> GetAllAsync()
        {
            var classRegistrations = await _classRegistrationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClassRegistrationDTO>>(classRegistrations);
        }

        public async Task<ClassRegistrationDTO> GetByIdAsync(int id)
        {
            var classRegistration = await _classRegistrationRepository.GetByIdAsync(id);
            return _mapper.Map<ClassRegistrationDTO>(classRegistration);
        }

        public async Task AddAsync(ClassRegistrationDTO classRegistrationDTO)
        {
            var classRegistration = _mapper.Map<ClassRegistration>(classRegistrationDTO);
            await _classRegistrationRepository.AddAsync(classRegistration);
        }

        public async Task UpdateAsync(ClassRegistrationDTO classRegistrationDTO)
        {
            var classRegistration = _mapper.Map<ClassRegistration>(classRegistrationDTO);
            await _classRegistrationRepository.UpdateAsync(classRegistration);
        }

        public async Task DeleteAsync(int id)
        {
            await _classRegistrationRepository.DeleteAsync(id);
        }
    }
}
