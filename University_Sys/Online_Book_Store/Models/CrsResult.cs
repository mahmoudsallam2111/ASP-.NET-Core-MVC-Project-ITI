using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Book_Store.Models
{
    public class CrsResult
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int degree { get; set; }
      

        [ForeignKey("Course")]
        public int crs_id { get; set; }


        [ForeignKey("Trainee")]
        public int trainee_id { get; set; }

        public virtual Course Course { get; set; }
        public virtual Trainee Trainee { get; set; }

    }
}
