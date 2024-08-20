using AcademyApp.Application.Dtos.StudentDtos;
using AcademyApp.Core.Entities;

namespace AcademyApp.Application.Interfaces;

public interface IStudentService
{
    Task<List<Student>> GetAllAsync();
    Task CreateAsync(StudentCreateDto studentCreateDto);
}
