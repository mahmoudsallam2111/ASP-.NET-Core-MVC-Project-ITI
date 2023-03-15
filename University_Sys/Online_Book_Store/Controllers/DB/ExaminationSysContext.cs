using Microsoft.EntityFrameworkCore;
using Online_Book_Store.Models;

namespace Online_Book_Store.Controllers.DB
{
    public class ExaminationSysContext:DbContext
    {
        // dbcontext option carries the configuration information like connection string
        //this class has a generic parameter
        public ExaminationSysContext(DbContextOptions<ExaminationSysContext> options) : base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Trainee> trainees { get; set; }
        public DbSet<CrsResult> crsResults { get; set; }

        
    }
}
