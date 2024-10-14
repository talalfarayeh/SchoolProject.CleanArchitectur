using MediatR;
using SchoolProject.core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand :IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
