using AcademyApp.Application.Dtos.StudentDtos;
using AcademyApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get() => Ok(await _studentService.GetAllAsync());

        [HttpPost("")]
        public async Task<IActionResult> Post(StudentCreateDto studentCreateDto)
        {
            await _studentService.CreateAsync(studentCreateDto);
            return NoContent();
        }
    }
}
