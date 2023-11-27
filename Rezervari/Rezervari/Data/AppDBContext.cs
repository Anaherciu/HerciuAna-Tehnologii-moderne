using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rezervari.Models;

namespace Rezervari.Data
{
    public class AppDBContext:IdentityDbContext<IdentityUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) 
        {
                
        }

        public DbSet<MovieTypeModel> MovieTypes { get; set; }
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }
    }
}
