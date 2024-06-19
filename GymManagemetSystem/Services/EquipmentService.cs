using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagementSystem.DTOs;
using GymManagementSystem.Models;
using GymManagementSystem.Repositories;
using AutoMapper;

namespace GymManagementSystem.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;

        public EquipmentService(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EquipmentDTO>> GetAllAsync()
        {
            var equipment = await _equipmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EquipmentDTO>>(equipment);
        }

        public async Task<EquipmentDTO> GetByIdAsync(int id)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);
            return _mapper.Map<EquipmentDTO>(equipment);
        }

        public async Task AddAsync(EquipmentDTO equipmentDTO)
        {
            var equipment = _mapper.Map<Equipment>(equipmentDTO);
            await _equipmentRepository.AddAsync(equipment);
        }

        public async Task UpdateAsync(EquipmentDTO equipmentDTO)
        {
            var equipment = _mapper.Map<Equipment>(equipmentDTO);
            await _equipmentRepository.UpdateAsync(equipment);
        }

        public async Task DeleteAsync(int id)
        {
            await _equipmentRepository.DeleteAsync(id);
        }
    }
}
