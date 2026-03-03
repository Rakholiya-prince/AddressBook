using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Address_Book.Models
{
    public class Company
    {
        [Key]
        public int Company_ID { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string Company_Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact Person is required")]
        public string ContactPerson { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Industry is required")]
        public int? Industry_ID { get; set; }

        [ForeignKey(nameof(Industry_ID))]
        public Industry? Industry { get; set; }
    }
}
