using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace Group6_Fashion_Merchandise.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
