using System;

namespace TryAPI.DTOs;

public class ProfessorGetDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Subject { get; set; }

    public ICollection<StudentListItemDto> Students { get; set; } = [];

}
