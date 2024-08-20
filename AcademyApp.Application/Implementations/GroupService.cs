using AcademyApp.Application.Dtos.GroupDtos;
using AcademyApp.Application.Exceptions;
using AcademyApp.Application.Interfaces;
using AcademyApp.Core.Entities;
using AcademyApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademyApp.Application.Implementations;

public class GroupService : IGroupService
{
    private readonly AcademyContext _context;

    public GroupService(AcademyContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(GroupCreateDto groupCreateDto)
    {
        if (await _context.Groups.AnyAsync(g => g.Name == groupCreateDto.Name)) throw new DuplicateEntityException("Duplicate group");
        Group group = new()
        {
            Name = groupCreateDto.Name,
            Limit = groupCreateDto.Limit,
            CreatedAt = DateTime.UtcNow,
        };
        await _context.Groups.AddAsync(group);
        await _context.SaveChangesAsync();
    }

    public Task<List<Group>> GetAllAsync()
    {
        return _context.Groups.ToListAsync();
    }
}
