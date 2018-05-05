using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using StudentWebMarket.Data.EF;
using StudentWebMarket.Models.Models;
using System;
using System.IO;

[assembly: OwinStartupAttribute(typeof(StudentWebMarket.Web.Startup))]
namespace StudentWebMarket.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        private void createRolesandUsers()
        {
            StudentWebMarketDbContext context = new StudentWebMarketDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<User>(new UserStore<User>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new IdentityRole
                {
                    Name = "Admin"

                };
                roleManager.Create(role);

                //creating a Admin super user who will maintain the website
                var user = new User
                {
                    UserName = "Admin",
                    Email = "Admin@gmail.com",
                    UserPhoto = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "C:/Users/Navn/Source/Repos/StudentWebMarket/StudentWebMarket.Data/Migrations/Images/admin.jpg")),
                };

                string userPWD = "Admin123*";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating regular user role    
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }
        }
    }
}
