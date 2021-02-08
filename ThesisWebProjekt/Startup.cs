﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThesisWebProjekt.Data;
using ThesisWebProjekt.Models;
using Microsoft.AspNetCore.Identity;

namespace ThesisWebProjekt
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<ThesisDBContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ThesisDBContext")));

 /*           //hier eigentlich die zwei DB kombinieren?
            services.AddDbContext<ThesisIdentityContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ThesisIdentityContextConnection"))); */

            services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ThesisDBContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> um, RoleManager<IdentityRole> rm)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            //Wie in der Vorlesung standardmäßig ein Administrator zum Testen
            CreateUserRoles(um, rm).Wait();
        }

        private async Task CreateUserRoles(UserManager<AppUser> um, RoleManager<IdentityRole> rm)
        {
            AppUser user = await um.FindByNameAsync("testadmin@gmail.com");
            if(user == null)
            {
                user = new AppUser() { Email = "testadmin@gmail.com", UserName = "testadmin@gmail.com" };
                await um.CreateAsync(user, "_PasswortAdmin321");
            }

            IdentityRole role = await rm.FindByNameAsync("Admin");
            if (role == null)
            {
                role = new IdentityRole("Admin");
                await rm.CreateAsync(role);
            }

            bool inrole = await um.IsInRoleAsync(user, "Admin");
            if (!inrole)
                await um.AddToRoleAsync(user, "Admin");

            return;
        }
    }
}
