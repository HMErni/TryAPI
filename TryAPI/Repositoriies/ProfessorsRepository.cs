using System;
using Microsoft.EntityFrameworkCore;
using TryAPI.Model;
using TryAPI.Persistence;

namespace TryAPI.Repositoriies;

public class ProfessorsRepository(DBContext context) : IProfessorRepository
{
    public async Task<long> AddProfessor(Professor professor)
    {
        await context.Professors.AddAsync(professor);
        await context.SaveChangesAsync();

        return professor.Id;
    }

    public async Task<Professor?> GetProfessorById(long id)
    {
        var professor = await context.Professors.Include(s => s.Students).FirstOrDefaultAsync(p => p.Id == id);

        return professor;
    }
}
