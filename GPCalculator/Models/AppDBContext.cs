using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPCalculator.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
            
        }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
           
        }

        public DbSet<Result> Results { get; set; }
        public List<Course> Course { get; set; }
        public DbSet<Course> Courses { get; set; } 
    }
}
