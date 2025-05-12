using System.ComponentModel.DataAnnotations;

namespace Group6_Fashion_Merchandise.Models
{
    public class CheckoutViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
