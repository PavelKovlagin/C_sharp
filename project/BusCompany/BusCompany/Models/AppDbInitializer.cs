using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BusCompany.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //создаем четыре роли
            var role1 = new IdentityRole { Name = "director" };
            var role2 = new IdentityRole { Name = "logist" };
            var role3 = new IdentityRole { Name = "driver" };
            var role4 = new IdentityRole { Name = "client" };

            //добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);
            roleManager.Create(role4);

            //создаем пользователей
            var director = new ApplicationUser
            {
                surname = "Батьков",
                name = "Батька",
                patronymic = "Батькович",
                UserName = "director@mail.ru",
                Email = "director@mail.ru",
                role = "Директор"
            };
            string password = "111222";
            var result = userManager.Create(director, password);
            //если слздание пользователя успешно
            userManager.AddToRole(director.Id, role1.Name);
            if (result.Succeeded)
            {
                //добпаляем для пользователя роль
                
            }
            base.Seed(context);
        }
    }
}