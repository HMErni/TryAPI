using System;
using TryAPI.Model;

namespace TryAPI.Repositoriies;

public interface IProfessorRepository
{
    Task<Professor?> GetProfessorById(long id);
    Task<long> AddProfessor(Professor professor);

}
