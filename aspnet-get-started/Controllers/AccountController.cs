using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using aspnet_get_started.Models;

namespace aspnet_get_started.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToLocal(returnUrl);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var configuredUsername = ConfigurationManager.AppSettings["AuthUsername"] ?? "admin";
            var configuredPassword = ConfigurationManager.AppSettings["AuthPassword"] ?? "admin";

            if (string.Equals(model.Username, configuredUsername, StringComparison.Ordinal)
                && string.Equals(model.Password, configuredPassword, StringComparison.Ordinal))
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError("", "Invalid username or password.");
            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
