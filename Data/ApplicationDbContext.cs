using Microsoft.EntityFrameworkCore;
using OncoAIApp.Models;

namespace OncoAIApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Patient> Patients { get; set; }
    }
}