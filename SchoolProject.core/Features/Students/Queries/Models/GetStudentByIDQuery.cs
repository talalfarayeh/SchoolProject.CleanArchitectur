using MediatR;
using SchoolProject.core.Bases;
using SchoolProject.core.Features.Students.Queries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.core.Features.Students.Queries.Models
{
     public class GetStudentByIDQuery : IRequest<Response<GetSingleStudentResponse>>
    {
        public int Id { get; set; }
        public GetStudentByIDQuery(int id)

        {
            Id = id;
        }

    }
}
