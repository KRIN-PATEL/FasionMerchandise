using System.ComponentModel.DataAnnotations;

namespace Group6_Fashion_Merchandise.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [MinLength(10, ErrorMessage = "Message must be at least 10 characters")]
        public string Message { get; set; }
    }
}
