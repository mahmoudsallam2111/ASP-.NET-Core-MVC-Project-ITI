using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Book_Store.Models
{
    public class Course
    {


        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Degree { get; set; }
        [Required]
        public int Mindegree { get; set; }


        [ForeignKey("Department")]
        public int dept_id { get; set; }

        public virtual Department Department { get; set; }

        public List<CrsResult>? crsResults { get; set; }
        public List<Instructor>? instructors { get; set; }

    }
}
