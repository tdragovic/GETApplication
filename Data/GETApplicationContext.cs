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

        public DbSet<GETApplication.Models.Subject> Predmet { get; set; }
        public DbSet<GETApplication.Models.Student> Student { get; set; }
        public DbSet<GETApplication.Models.Exam> Exam { get; set; }
    }
}
