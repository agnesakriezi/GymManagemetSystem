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
    public class MembershipsController : ControllerBase
    {
        private readonly IMembershipService _membershipService;

        public MembershipsController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMembershipById(int id)
        {
            var membership = await _membershipService.GetMembershipByIdAsync(id);
            if (membership == null)
                return NotFound();

            return Ok(membership);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMemberships()
        {
            var memberships = await _membershipService.GetAllMembershipsAsync();
            return Ok(memberships);
        }

        [HttpPost]
        public async Task<IActionResult> AddMembership(MembershipDTO membershipDto)
        {
            var membership = await _membershipService.AddMembershipAsync(membershipDto);
            return CreatedAtAction(nameof(GetMembershipById), new { id = membership.Id }, membership);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMembership(int id, MembershipDTO membershipDto)
        {
            var membership = await _membershipService.UpdateMembershipAsync(id, membershipDto);
            if (membership == null)
                return NotFound();

            return Ok(new { message = "Membership updated successfully", membership });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembership(int id)
        {
            await _membershipService.DeleteMembershipAsync(id);
            return Ok(new { message = "Membership deleted successfully" });
        }
    }
}
