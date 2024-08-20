using AcademyApp.Application.Dtos.StudentDtos;
using AcademyApp.Application.Exceptions;
using AcademyApp.Application.Extensions;
using AcademyApp.Application.Interfaces;
using AcademyApp.Core.Entities;
using AcademyApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademyApp.Application.Implementations;

public class StudentService : IStudentService
{
    private readonly AcademyContext _context;

    public StudentService(AcademyContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(StudentCreateDto studentCreateDto)
    {
        Group? group = await _context.Groups.SingleOrDefaultAsync(g => g.Id == studentCreateDto.GroupId);
        if (group == null) throw new EntityDoesNotExistException("Group does not exist");
        if (!studentCreateDto.Image.IsImage()) throw new Exceptions.InvalidDataException("Invalid format");
        if (studentCreateDto.Image.DoesSizeExceed(100)) throw new Exceptions.InvalidDataException("File size is too large");
        string filename = await studentCreateDto.Image.SaveFileAsync();
        Student student = new()
        {
            Name = studentCreateDto.Name,
            Email = studentCreateDto.Email,
            FileName = filename,
            GroupId = studentCreateDto.GroupId,
            BirthDate = studentCreateDto.BirthDate,
            CreatedAt = DateTime.UtcNow,
        };
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _context.Students.ToListAsync();
    }
}
