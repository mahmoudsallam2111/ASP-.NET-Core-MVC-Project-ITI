using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Book_Store.Models
{
    public class Trainee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }

        public string Address { get; set; }

        [Required]
        public string Grade { get; set; }

        [ForeignKey("Department")]
        public int dept_id { get; set; }

        public virtual Department Department { get; set; }

       public List<CrsResult> crsResults { get; set; }    

        
    }
}
