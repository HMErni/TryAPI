using System;
using Microsoft.EntityFrameworkCore;

namespace TryAPI.Model;

public class Professor
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Subject { get; set; }

    public virtual ICollection<Student> Students { get; set; } = [];
}
