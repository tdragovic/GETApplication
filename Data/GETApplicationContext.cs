using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GETApplication.Models;

namespace GETApplication.Data
{
    public class GETApplicationContext : DbContext
    {
        public GETApplicationContext (DbContextOptions<GETApplicationContext> options)
            : base(options)
        {
            
        }

        public DbSet<Subject> Predmet { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Exam> Exam { get; set; }
    }
}
