using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcBook.Areas.Identity.Data;
using MvcBook.Data;
using MvcBook.Models;

[assembly: HostingStartup(typeof(MvcBook.Areas.Identity.IdentityHostingStartup))]
namespace MvcBook.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MvcBookContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MvcBookContext")));

                services.AddDefaultIdentity<CBAUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;


                })

             .AddRoles<IdentityRole>()
             
             .AddEntityFrameworkStores<MvcBookContext>();
           
 
                

            });
            
        }
    }
}