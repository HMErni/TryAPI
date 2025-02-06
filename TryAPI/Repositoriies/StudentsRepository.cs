using System;
using Microsoft.EntityFrameworkCore;
using TryAPI.Model;
using TryAPI.Persistence;

namespace TryAPI.Repositoriies;

public class StudentsRepository(DBContext context) : IStudentsRepository
{
    public async Task<long> AddStudent(Student student)
    {
        await context.Students.AddAsync(student);
        await context.SaveChangesAsync();

        return student.Id;
    }

    public async Task<Student?> AssignProfessor(Student student)
    {
        context.Update(student);
        await context.SaveChangesAsync();

        return student;

    }

    public async Task<Student?> GetStudentById(long id)
    {
        var student = await context.Students.Include(p => p.Professors).FirstOrDefaultAsync(s => s.Id == id);

        return student;
    }
}
