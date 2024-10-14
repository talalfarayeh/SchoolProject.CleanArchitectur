using SchoolProject.core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.core.Mapping.StudentM
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>()
                .ForMember(dest => dest.DID, opt => opt.MapFrom(sor => sor.DepartmentId)).
                ForMember(dest=>dest.StudID,opt=>opt.MapFrom(sor => sor.Id));

        }
    }
}
