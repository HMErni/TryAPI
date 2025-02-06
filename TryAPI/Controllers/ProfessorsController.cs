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
    public class ProfessorsController : ControllerBase
    {
        private readonly IProfessorRepository _repository;
        private readonly IMapper _mapper;

        public ProfessorsController(
            IProfessorRepository repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var professor = await _repository.GetProfessorById(id);
            if (professor == null)
            {
                return NotFound();
            }

            var professorDto = _mapper.Map<ProfessorGetDto>(professor);

            return Ok(professorDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddProfessor([FromBody] ProfessorDto professorDto)
        {
            var professor = _mapper.Map<Professor>(professorDto);
            var id = await _repository.AddProfessor(professor);

            return CreatedAtAction(nameof(GetById), new { id = id }, _mapper.Map<ProfessorDto>(professor));
        }
    }
}

