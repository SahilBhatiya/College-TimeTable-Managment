using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeTable_Creator.Models;

namespace TimeTable_Creator.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options )
            : base(options)
        {
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Slot> Slots { get; set; }

    }
}