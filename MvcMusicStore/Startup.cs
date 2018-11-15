using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MvcMusicStore.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcMusicStore.Startup))]
namespace MvcMusicStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // create original admin role and user
            const string roleName = "Admin";
            if (!roleManager.RoleExists(roleName))
            {
                // 1 create Admin role
                var role = new IdentityRole();
                role.Name = roleName;
                roleManager.Create(role);

                // 2 create create Admin user
                var user = new ApplicationUser();
                user.UserName = "lotophagos";
                user.Email = "lotophagos@live.co.uk";
                string userPWD = "password";
                IdentityResult chkUser = userManager.Create(user, userPWD);

                // 3 add user to Admin
                if (chkUser.Succeeded)
                {
                    IdentityResult result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
