using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.core.Features.Students.Commands.Models;
using SchoolProject.core.Features.Students.Queries.Models;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet("getStudentList")]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }
        [HttpGet("getStudentById/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var response = await _mediator.Send(new GetStudentByIDQuery(id));
            return Ok(response);
        }
        [HttpPost("addStudent")]
        public async Task<IActionResult> AddStudent([FromBody]AddStudentCommand addStudent)
        {
            var response = await _mediator.Send(addStudent);
            return Ok(response);
        }
        [HttpPut("addStudent")]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand editStudent)
        {
            var response = await _mediator.Send(editStudent);
            return Ok(response);
        }
        [HttpDelete("deleteStudentById/{id}")]
        public async Task<IActionResult> DeleteStudentById(int id)
        {
            var response = await _mediator.Send(new DeleteStudentCommand(id));
            return Ok(response);
        }
    }
}
