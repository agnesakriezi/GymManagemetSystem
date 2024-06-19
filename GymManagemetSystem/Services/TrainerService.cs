using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagementSystem.DTOs;
using GymManagementSystem.Models;
using GymManagementSystem.Repositories;
using AutoMapper;

namespace GymManagementSystem.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;

        public TrainerService(ITrainerRepository trainerRepository, IMapper mapper)
        {
            _trainerRepository = trainerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TrainerDTO>> GetAllAsync()
        {
            var trainers = await _trainerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TrainerDTO>>(trainers);
        }

        public async Task<TrainerDTO> GetByIdAsync(int id)
        {
            var trainer = await _trainerRepository.GetByIdAsync(id);
            return _mapper.Map<TrainerDTO>(trainer);
        }

        public async Task AddAsync(TrainerDTO trainerDTO)
        {
            var trainer = _mapper.Map<Trainer>(trainerDTO);
            await _trainerRepository.AddAsync(trainer);
        }

        public async Task UpdateAsync(TrainerDTO trainerDTO)
        {
            var trainer = _mapper.Map<Trainer>(trainerDTO);
            await _trainerRepository.UpdateAsync(trainer);
        }

        public async Task DeleteAsync(int id)
        {
            await _trainerRepository.DeleteAsync(id);
        }
    }
}
