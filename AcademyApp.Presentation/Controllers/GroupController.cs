using AcademyApp.Application.Dtos.GroupDtos;
using AcademyApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get() => Ok(await _groupService.GetAllAsync());

        [HttpPost("")]
        public async Task<IActionResult> Post(GroupCreateDto groupCreateDto)
        {
            await _groupService.CreateAsync(groupCreateDto);
            return NoContent();
        }
    }
}
