using Microsoft.EntityFrameworkCore;
using NotesAppAspNet.Models;
using c__mat_zad.Models;

namespace NotesAppAspNet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
