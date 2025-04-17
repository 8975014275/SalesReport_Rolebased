using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalesReport.Models;

namespace SalesReport.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {

        }
        public DbSet<SalesLead> SalesLeads { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

    }
}
