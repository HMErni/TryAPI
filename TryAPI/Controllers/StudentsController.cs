using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryAPI.DTOs;
using TryAPI.Model;
using TryAPI.Repositoriies;

namespace TryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStudentsRepository _studentsRepository;
        private readonly IProfessorRepository _professorRepository;

        public StudentsController(
            IMapper mapper,
            IStudentsRepository studentsRepository,
            IProfessorRepository professorRepository
        )
        {
            _mapper = mapper;
            _studentsRepository = studentsRepository;
            _professorRepository = professorRepository;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(long id)
        {
            var student = await _studentsRepository.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            var studentDto = _mapper.Map<StudentGetDto>(student);

            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDto student)
        {
            var _student = _mapper.Map<Student>(student);

            var student_id = await _studentsRepository.AddStudent(_student);

            return CreatedAtAction(nameof(GetStudentById), new { id = student_id }, _student);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AssignProfessorToStudent([FromRoute] long id, [FromBody] long professorId)
        {
            var _student = await _studentsRepository.GetStudentById(id);

            if (_student == null)
            {
                return NotFound();
            }

            var _professor = await _professorRepository.GetProfessorById(professorId);

            if (_professor == null)
            {
                return NotFound();
            }

            _student.Professors.Add(_professor);

            await _studentsRepository.AssignProfessor(_student);

            var student = _mapper.Map<StudentGetDto>(_student);

            return Ok(student);
        }
    }
}
