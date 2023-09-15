using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using XrayProWebApp.Models;

namespace XrayProWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            EnsureRolesExist(); //initialise roles if not exists
            EnsureRoomsExist(); //populate the room
        }

        private void EnsureRolesExist()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole("Customer");
                roleManager.Create(role);
            }
        }

        private void EnsureRoomsExist()
        {
            var context = new ApplicationDbContext();

            var roomNumbers = new List<string>
            {
                "A101",
                "A201",
                "A301",
                "A401",
                "B101",
                "B201",
                "C101",
                "C201"
            };

            foreach (var roomNumber in roomNumbers)
            {
                if (!context.Rooms.Any(r => r.Number == roomNumber))
                {
                    var room = new Room
                    {
                        Id = Guid.NewGuid().ToString(), // Generating a new GUID as a string for the Id column
                        Number = roomNumber
                    };
                    context.Rooms.Add(room);
                }
            }

            context.SaveChanges();
        }

    }
}
