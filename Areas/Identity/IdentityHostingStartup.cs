using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TM470.Areas.Identity.Data;
using TM470.Data;

[assembly: HostingStartup(typeof(TM470.Areas.Identity.IdentityHostingStartup))]
namespace TM470.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TM470Context>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("TM470ContextConnection")));

               // services.AddDefaultIdentity<TM470User>(options => options.SignIn.RequireConfirmedAccount = true)
               //     .AddEntityFrameworkStores<TM470Context>();
            });
        }
    }
}