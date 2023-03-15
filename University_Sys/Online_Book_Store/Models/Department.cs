using System.ComponentModel.DataAnnotations;

namespace Online_Book_Store.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string? Manger{ get; set; }

      public  List<Trainee> Trainees { get; set; }
       public List<Instructor> Instructors { get; set; }
       public List<Course> Courses { get; set; }  

    }
}
