using GymManagementSystem.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Services
{
    public interface IBillingService
    {
        Task<BillingDTO> GetBillingByIdAsync(int id);
        Task<IEnumerable<BillingDTO>> GetAllBillingsAsync();
        Task<BillingDTO> AddBillingAsync(BillingDTO billingDto);
        Task<BillingDTO> UpdateBillingAsync(int id, BillingDTO billingDto);
        Task DeleteBillingAsync(int id);
    }
}
