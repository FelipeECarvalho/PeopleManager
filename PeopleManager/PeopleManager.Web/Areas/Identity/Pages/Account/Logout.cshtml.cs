﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleManager.Infrastructure.Identity;
using System.Threading.Tasks;

namespace PeopleManager.Web.Areas.Identity.Pages.Account
{
    public class LogoutModel(SignInManager<ApplicationUser> signInManager) : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return RedirectToPage();
            }
        }
    }
}
