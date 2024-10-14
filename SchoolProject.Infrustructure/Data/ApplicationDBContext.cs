﻿using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Data
{
     public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
            
        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options) 
        {
            
        }
        public DbSet<Department>departments { get; set; }
        public DbSet<DepartmetSubject> departmetSubjects { get; set; }
        public DbSet<Student>  students { get; set; }
        public DbSet<StudentSubject>  studentSubjects { get; set; }
        public DbSet<Subjects> subjects { get; set; }
    }
}
