using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrustructure.Repository.IRepository;
using SchoolProject.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsAsync();
        }
        public async  Task<Student> GetStudentsByIdAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking().Include(x=>x.Department).Where(x=>x.StudID.Equals(id)).FirstOrDefault();
            return student;
        }

        public async Task<string> AddAsync(Student student)
        {
            var studentResult = _studentRepository.GetTableNoTracking().Where(x => x.Name.Equals(student.Name)).FirstOrDefault();
            if (studentResult != null)  return "Exist";
            await _studentRepository.AddAsync(student);
            return "Success";
        }

        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();

                return "Success";
            }
            catch { 

             await trans.RollbackAsync();
                return "Falied";
            }
            

        }
    }
}
