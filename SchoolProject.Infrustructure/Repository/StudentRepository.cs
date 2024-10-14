using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrustructure.Bases;
using SchoolProject.Infrustructure.Data;
using SchoolProject.Infrustructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Repository
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        private readonly DbSet<Student> _student;
        public StudentRepository(ApplicationDBContext dbcontecxt):base(dbcontecxt) 
        {
            _student = dbcontecxt.Set<Student>();
        }
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _student.Include(x=>x.Department).ToListAsync();
        }
    }
}
