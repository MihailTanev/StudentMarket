using StudentWebMarket.Data.EF;
using StudentWebMarket.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWebMarket.Web.Controllers
{
    public class UsersController : Controller
    {
        private StudentWebMarketDbContext context = new StudentWebMarketDbContext();
        public ActionResult ManageUsers()
        {
            var users = (from user in context.Users
                                  select new
                                  {
                                      PhoneNumber=user.PhoneNumber,
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      FirstName = user.FirstName,
                                      LastName=user.LastName,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new UsersViewModel()

                                  {
                                      PhoneNumber=p.PhoneNumber,
                                      FirstName = p.FirstName,
                                      LastName=p.LastName,
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });


            return View(users);
        }
    }
}