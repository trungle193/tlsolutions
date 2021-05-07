using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using TLSolutions.Areas.Identity;
using TLSolutions.Configurations.Email;
using TLSolutions.Data;
using TLSolutions.Entities.Identity;

namespace TLSolutions.Configurations
{
    public static class ConfigureIdentityServices
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            }).AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddSignInManager<AppSignInManager>()
            .AddUserManager<AppUserManager>()
            .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, EmailSender>();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Logout";
                options.AccessDeniedPath = "/AccessDenied";
            });


            services.AddAuthorization(options =>
            {
                options.AddPolicy("ViewRole", p => p.RequireClaim(Identity.Constants.PERMISSION, "role.view"));
                options.AddPolicy("CreateRole", p => p.RequireClaim(Identity.Constants.PERMISSION, "role.create"));
                options.AddPolicy("EditRole", p => p.RequireClaim(Identity.Constants.PERMISSION, "role.edit"));
                options.AddPolicy("DeleteRole", p => p.RequireClaim(Identity.Constants.PERMISSION, "role.delete"));

                options.AddPolicy("ViewUser", p => p.RequireClaim(Identity.Constants.PERMISSION, "user.view"));
                options.AddPolicy("CreateUser", p => p.RequireClaim(Identity.Constants.PERMISSION, "user.create"));
                options.AddPolicy("EditUser", p => p.RequireClaim(Identity.Constants.PERMISSION, "user.edit"));
                options.AddPolicy("DeleteUser", p => p.RequireClaim(Identity.Constants.PERMISSION, "user.delete"));

                //options.AddPolicy("ViewRole", p => { p.RequireRole("Admin"); });
                //options.AddPolicy("CreateRole", p => { p.RequireRole("Admin"); });
                //options.AddPolicy("EditRole", p => { p.RequireRole("Admin"); });
                //options.AddPolicy("DeleteRole", p => { p.RequireRole("Admin"); });

                //options.AddPolicy("ViewUser", p => { p.RequireRole("Admin"); });
                //options.AddPolicy("CreateUser", p => { p.RequireRole("Admin"); });
                //options.AddPolicy("EditUser", p => { p.RequireRole("Admin"); });
                //options.AddPolicy("DeleteUser", p => { p.RequireRole("Admin"); });
            });
        }
    }
}
