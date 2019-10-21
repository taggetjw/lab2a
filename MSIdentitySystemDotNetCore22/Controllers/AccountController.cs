using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MSIdentitySystemDotNetCore22.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MSIdentitySystemDotNetCore22.Models;

namespace MSIdentitySystemDotNetCore22.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> RoleManager)
        {
            _userManager = userManager;
            _roleManager = RoleManager;
        }
        public async Task<IActionResult> SeedRoles()
        {
            ApplicationUser user1 = new ApplicationUser
            {
                Email = "John@doe.com",
                UserName = "John@doe.com",
                Department = "IT"
            };
            ApplicationUser user2 = new ApplicationUser
            {
                Email = "Jane@doe.com",
                UserName = "Jane@doe.com",
                Department = "Finance"
            };
            IdentityResult result = await _userManager.CreateAsync(user1, "Mohawk1!");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new user" });

            result = await _userManager.CreateAsync(user2, "Mohawk1!");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new user" });

            result = await _roleManager.CreateAsync(new IdentityRole("Member"));
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new role" });

            result = await _roleManager.CreateAsync(new IdentityRole("Admin"));
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new role" });


            result = await _userManager.AddToRoleAsync(user1, "Member");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to assign new role" });

            result = await _userManager.AddToRoleAsync(user2, "Admin");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to assign new role" });


            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> SeedClaims()
        {
            ApplicationUser user1 = new ApplicationUser
            {
                Email = "Full@Access.com",
                UserName = "Full@Access.com",
                Department = "IT"
            };
            IdentityResult result = await _userManager.CreateAsync(user1, "Mohawk1!");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new user" });

            result = await _userManager.AddToRoleAsync(user1, "Admin");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to assign new role" });

            result = await _userManager.AddClaimAsync(user1, new Claim(ClaimTypes.Email, user1.Email));
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to assign new claim" });

            return RedirectToAction("Index", "Home");
        }


    }
}