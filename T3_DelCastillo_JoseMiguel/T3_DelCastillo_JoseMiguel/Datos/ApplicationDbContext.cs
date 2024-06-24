using Microsoft.EntityFrameworkCore;
using T3_DelCastillo_JoseMiguel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace T3_DelCastillo_JoseMiguel.Datos
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Libro> Libro { get; set; }
    }
}
