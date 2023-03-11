using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Online_Book_Store.Models
{
    public class Clategory
    {
        [Key]
       public int Id { get; set; }

        [Required]
        [DisplayName("category name")]
        public string Name { get; set; }

        [DisplayName("number of order")]
        [Range(1, 100, ErrorMessage = "Please enter value between 1 and 100")]


        public int DisplayedOrder { get; set; }

        public DateTime createdDateTime { get; set; } = DateTime.Now;
    }
}
