using GymManagementSystem.DTOs;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDTO>>> GetAll()
        {
            var members = await _memberService.GetAllAsync();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDTO>> GetById(int id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] MemberDTO memberDto)
        {
            await _memberService.AddAsync(memberDto);
            return CreatedAtAction(nameof(GetById), new { id = memberDto.MemberId }, memberDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] MemberDTO memberDto)
        {
            if (id != memberDto.MemberId)
            {
                return BadRequest();
            }

            await _memberService.UpdateAsync(memberDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _memberService.DeleteAsync(id);
            return NoContent();
        }
    }
}
