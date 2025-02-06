using System;
using TryAPI.Model;

namespace TryAPI.Repositoriies;

public interface IStudentsRepository
{
    Task<Student?> GetStudentById(long id);
    Task<long> AddStudent(Student student);
    Task<Student?> AssignProfessor(Student student);
}
