using GymManagementSystem.DTOs;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class BillingsController : ControllerBase
    {
        private readonly IBillingService _billingService;

        public BillingsController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillingById(int id)
        {
            var billing = await _billingService.GetBillingByIdAsync(id);
            if (billing == null)
                return NotFound();

            return Ok(billing);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBillings()
        {
            var billings = await _billingService.GetAllBillingsAsync();
            return Ok(billings);
        }

        [HttpPost]
        public async Task<IActionResult> AddBilling(BillingDTO billingDto)
        {
            var billing = await _billingService.AddBillingAsync(billingDto);
            return CreatedAtAction(nameof(GetBillingById), new { id = billing.Id }, billing);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBilling(int id, BillingDTO billingDto)
        {
            var billing = await _billingService.UpdateBillingAsync(id, billingDto);
            if (billing == null)
                return NotFound();

            return Ok(new { message = "Billing updated successfully", billing });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBilling(int id)
        {
            await _billingService.DeleteBillingAsync(id);
            return Ok(new { message = "Billing deleted successfully" });
        }
    }
}
