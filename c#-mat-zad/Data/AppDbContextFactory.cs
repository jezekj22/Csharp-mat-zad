using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NotesAppAspNet.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=db.bsmsajmzrpdstssrvggk.supabase.co;Database=postgres;Username=postgres;Password=opravdusilneheslo;SSL Mode=Require;Trust Server Certificate=true");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
