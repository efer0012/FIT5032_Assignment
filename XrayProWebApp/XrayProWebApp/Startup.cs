using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using XrayProWebApp.Models;

[assembly: OwinStartupAttribute(typeof(XrayProWebApp.Startup))]
namespace XrayProWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var context = new ApplicationDbContext(); 
            var userStore = new UserStore<ApplicationUser>(context);
            var roleStore = new RoleStore<IdentityRole>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            ConfigureAuth(app, userManager, roleManager);
        }
    }
}
