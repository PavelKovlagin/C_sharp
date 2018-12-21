using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BusCompany.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace BusCompany.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        [Authorize (Roles = "director")]
        public ActionResult UsersList()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return View(db.Users.ToList());
            }
        }

        [Authorize(Roles = "director")]
        [HttpGet]
        public ActionResult DriverAdd()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DriverAdd(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    surname = model.surname,
                    name = model.name,
                    patronymic = model.patronymic,
                    UserName = model.Email,
                    Email = model.Email,
                    role = "Водитель"
                };

                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "driver");
                    return RedirectToAction("UsersList", "Account");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return RedirectToAction("UsersList", "Account");
        }

        [Authorize(Roles = "director")]
        [HttpGet]
        public ActionResult LogistAdd()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogistAdd(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    surname = model.surname,
                    name = model.name,
                    patronymic = model.patronymic,
                    UserName = model.Email,
                    Email = model.Email,
                    role = "Логист"
                    
                };

                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "logist");
                    return RedirectToAction("UsersList", "Account");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return RedirectToAction("UsersList", "Account");
        }

        [HttpGet]
        public ActionResult WorkWithAccount()
        {
            ApplicationUser user = UserManager.FindByEmail(User.Identity.Name);
            ViewBag.user = user;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    surname = model.surname,
                    name = model.name,
                    patronymic = model.patronymic,
                    UserName = model.Email,
                    Email = model.Email,
                    role = "Клиент"
                };

                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "client");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View();
        }

        private IAuthenticationManager AuthorizationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindAsync(
                    model.Email, 
                    model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
                else
                {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthorizationManager.SignOut();
                    AuthorizationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    if (String.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("WorkWithAccount", "Account");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        public ActionResult Logout()
        {
            AuthorizationManager.SignOut();
            return RedirectToAction("WorkWithAccount", "Account");
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed()
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Logout", "Account");
                }
            }
            return RedirectToAction("WorkWithAccount", "Account");
        }

        public ActionResult Edit()
        {
            ApplicationUser user = UserManager.FindByEmail(User.Identity.Name);
            if (user != null)
            {
                EditModel model = new EditModel {
                    surname = user.surname,
                    name = user.name,
                    patronymic = user.patronymic,
                    email = user.Email,
                    role = user.role,
                };
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        [Authorize(Roles = "director")]
        [HttpGet]
        public ActionResult UserDelete(string id)
        {
            ApplicationUser user = UserManager.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.User = user;
            return View();
        }

        [HttpPost, ActionName("UserDelete")]
        public ActionResult UserDeleteConfirmed(string id)
        {
            ApplicationUser user = UserManager.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            IdentityResult result = UserManager.Delete(user);
            return RedirectToAction("UsersList", "Account");
        }
    }
}