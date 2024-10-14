using AutoMapper;
using MediatR;
using SchoolProject.core.Bases;
using SchoolProject.core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandlers : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>,
        IRequestHandler<EditStudentCommand, Response<string>>,
        IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentCommandHandlers(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;

        }
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = _mapper.Map<Student>(request);
            var result = await _studentService.AddAsync(studentMapper);
            if (result == "Exist") return UnprocessableEntity<string>("Name is Exist");
            else if (result == "Success") return Created("Added Sussessfully");
            else return BadRequest<string>();


        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentsByIdAsync(request.Id);
            if (student == null) return BadRequest<string>("Student is not found");
            var studentMapper = _mapper.Map<Student>(request);
            var result = await _studentService.EditAsync(studentMapper);
            if (result == "Success") return Success("Edit Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentsByIdAsync(request.Id);
            if (student == null) return BadRequest<string>("Student is not found");

            var result = await _studentService.DeleteAsync(student);
            if (result == "Success") return Deleted<string>("Edit Sussessfully");
            else return BadRequest<string>();

        }




    }
}
