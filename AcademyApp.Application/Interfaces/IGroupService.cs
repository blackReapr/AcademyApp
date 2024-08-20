using AcademyApp.Application.Dtos.GroupDtos;
using AcademyApp.Core.Entities;

namespace AcademyApp.Application.Interfaces;

public interface IGroupService
{
    Task<List<Group>> GetAllAsync();
    Task CreateAsync(GroupCreateDto groupCreateDto);
}
