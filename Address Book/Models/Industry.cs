using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Address_Book.Models
{
    public class Industry
    {
        [Key]
        public int Industry_ID { get; set; }

        [Required]
        public string? Industry_Name { get; set; }

        public ICollection<Company>? Companies { get; set; }
    }
}
