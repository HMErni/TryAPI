using System;

namespace TryAPI.DTOs;

public class StudentDto
{
    public string Name { get; set; }

    public ICollection<long> ProfessorsIds { get; set; } = [];

}
