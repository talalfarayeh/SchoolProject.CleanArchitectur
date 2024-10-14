using AutoMapper;
using MediatR;
using SchoolProject.core.Bases;
using SchoolProject.core.Features.Students.Queries.Models;
using SchoolProject.core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.core.Features.Students.Queries.Handlers
{
    public class StudentHandlers : ResponseHandler,
        IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
          IRequestHandler<GetStudentByIDQuery, Response<GetSingleStudentResponse>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentHandlers(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList= await _studentService.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            return Success(studentListMapper);
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentsByIdAsync(request.Id);
            if (student == null) return NotFound<GetSingleStudentResponse>();
            var result = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(result);
        }

        


    }
}
