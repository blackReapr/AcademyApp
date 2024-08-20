using FluentValidation;

namespace AcademyApp.Application.Dtos.GroupDtos;

public class GroupCreateDto
{
    public string Name { get; set; }
    public int Limit { get; set; }
}

public class GroupCreateDtoValidator : AbstractValidator<GroupCreateDto>
{
    public GroupCreateDtoValidator()
    {
        RuleFor(g => g.Name).MaximumLength(5).NotEmpty();
        RuleFor(g => g.Limit).InclusiveBetween(5, 18);
    }
}
