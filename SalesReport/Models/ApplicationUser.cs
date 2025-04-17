using Microsoft.AspNetCore.Identity;
namespace SalesReport.Models
{
    public class ApplicationUser: IdentityUser
    {
        public String Firstname { get; set; }
        public String Lastname { get; set; }
    }
}
