using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Book_Store.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Salary { get; set; }

        public string Address { get; set; }
        [ForeignKey("Department")]
        public int? dept_id { get; set; }
        [ForeignKey("Course")]
        public int? crs_id { get; set; }

        public virtual Department? Department { get; set; }
        
        public virtual Course? Course { get; set; }

        
    }
}
