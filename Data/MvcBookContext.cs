using Microsoft.EntityFrameworkCore;
using MvcBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MvcBook.Areas.Identity.Data;

namespace MvcBook.Data
{
    public class MvcBookContext : IdentityDbContext<CBAUser>
    {
        public MvcBookContext(DbContextOptions<MvcBookContext> options)
            : base(options)
        {
        }
        
        /*  public DbSet<MvcBookUser> MvcBookUser { get; set; }*/
        public DbSet<CBAUser> CBAUser { get; set; }
        
       

        public DbSet<Role> Role { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

         
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        
       
    }
}

