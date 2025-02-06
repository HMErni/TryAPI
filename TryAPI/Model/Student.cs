using System;

namespace TryAPI.Model;

public class Student
{
    public long Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Professor> Professors { get; set; } = [];

}
