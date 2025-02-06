using System;

namespace TryAPI.DTOs;

public class StudentGetDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<ProfessorDto> Professors { get; set; } = [];

}
