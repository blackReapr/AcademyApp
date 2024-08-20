using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AcademyApp.Application.Dtos.StudentDtos;

public class StudentCreateDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int GroupId { get; set; }
    public IFormFile Image { get; set; }
    public DateTime BirthDate { get; set; }
}

public class StudentCreateDtoValidator : AbstractValidator<StudentCreateDto>
{
    public StudentCreateDtoValidator()
    {
        RuleFor(s => s.Name).NotEmpty().MaximumLength(30);
        RuleFor(s => s.Email).NotEmpty().EmailAddress().MaximumLength(100);
        RuleFor(s => s.Image).NotEmpty();
        RuleFor(s => s.GroupId).NotEmpty();
        RuleFor(s => s.BirthDate).NotEmpty().LessThan(DateTime.Now.AddYears(-18));
    }
}
