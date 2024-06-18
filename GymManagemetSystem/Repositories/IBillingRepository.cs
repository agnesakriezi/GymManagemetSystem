using GymManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Repositories
{
    public interface IBillingRepository
    {
        Task<Billing> GetBillingByIdAsync(int id);
        Task<IEnumerable<Billing>> GetAllBillingsAsync();
        Task AddBillingAsync(Billing billing);
        Task UpdateBillingAsync(Billing billing);
        Task DeleteBillingAsync(Billing billing);
    }
}
