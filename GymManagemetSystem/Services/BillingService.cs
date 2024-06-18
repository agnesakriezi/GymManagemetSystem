using GymManagementSystem.DTOs;
using GymManagementSystem.Models;
using GymManagementSystem.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Services
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;

        public BillingService(IBillingRepository billingRepository, IMapper mapper)
        {
            _billingRepository = billingRepository;
            _mapper = mapper;
        }

        public async Task<BillingDTO> GetBillingByIdAsync(int id)
        {
            var billing = await _billingRepository.GetBillingByIdAsync(id);
            return _mapper.Map<BillingDTO>(billing);
        }

        public async Task<IEnumerable<BillingDTO>> GetAllBillingsAsync()
        {
            var billings = await _billingRepository.GetAllBillingsAsync();
            return _mapper.Map<IEnumerable<BillingDTO>>(billings);
        }

        public async Task<BillingDTO> AddBillingAsync(BillingDTO billingDto)
        {
            var billing = _mapper.Map<Billing>(billingDto);
            await _billingRepository.AddBillingAsync(billing);
            return _mapper.Map<BillingDTO>(billing);
        }

        public async Task<BillingDTO> UpdateBillingAsync(int id, BillingDTO billingDto)
        {
            var billing = await _billingRepository.GetBillingByIdAsync(id);
            if (billing == null)
            {
                return null;
            }

            _mapper.Map(billingDto, billing);
            await _billingRepository.UpdateBillingAsync(billing);
            return _mapper.Map<BillingDTO>(billing);
        }

        public async Task DeleteBillingAsync(int id)
        {
            var billing = await _billingRepository.GetBillingByIdAsync(id);
            if (billing != null)
            {
                await _billingRepository.DeleteBillingAsync(billing);
            }
        }
    }
}
