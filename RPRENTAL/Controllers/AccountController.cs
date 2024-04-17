using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model;
using RPRENTAL.ViewModels;
using StaticUtility;

namespace RPRENTAL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userManager.Users
                .Select(user => new RegisterVM
                {
                    NAME = user.USER_NAME,
                    PASSWORD = user.PasswordHash,
                    CONFIRM_PASSWORD = user.PasswordHash,
                    EMAIL = user.Email,
                    PHONE_NUMBER = user.PhoneNumber,
                    ROLE = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault(),

        }).ToListAsync();

            return Json(new { data = users });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() => PartialView("Create", GetRegisterViewModel());

        [HttpPost]
        public async Task<IActionResult> Create(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Invalid model state" });

            var user = new ApplicationUser
            {
                USER_NAME = model.NAME,
                Email = model.EMAIL,
                PhoneNumber = model.PHONE_NUMBER,
                NormalizedEmail = model.EMAIL.ToUpper(),
                EmailConfirmed = true,
                UserName = model.EMAIL,
                CREATED_DATE = DateTime.Now
            };

            if (model.PASSWORD != model.CONFIRM_PASSWORD)
                return Json(new { success = false, message = "Passwords do not match" });

            var result = await _userManager.CreateAsync(user, model.PASSWORD);

            if (result.Succeeded)
            {
                await AddUserRole(user, model.ROLE);
                return Json(new { success = true, message = "Successfully registered" });
            }

            return Json(new { success = false, message = "Failed to register user" });
        }

        private async Task AddUserRole(ApplicationUser user, string role)
        {
            role ??= SD.UserRole.CUSTOMER.ToString();
            await _userManager.AddToRoleAsync(user, role);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var viewModel = GetRegisterViewModel();
            viewModel.EMAIL = user.Email;
            viewModel.NAME = user.USER_NAME;
            viewModel.PHONE_NUMBER = user.PhoneNumber;
            viewModel.ROLE = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            return PartialView("Update", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RegisterVM model)
        {
            var user = await _userManager.FindByEmailAsync(model.EMAIL);
            var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            try
            {
                await _userManager.RemoveFromRoleAsync(user, userRole);
                await AddUserRole(user, model.ROLE);

                user.USER_NAME = model.NAME;
                user.PhoneNumber = model.PHONE_NUMBER;

                if (!string.IsNullOrEmpty(model.PASSWORD))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    await _userManager.ResetPasswordAsync(user, token, model.PASSWORD);
                }

                await _userManager.UpdateAsync(user);

                return Json(new { success = true, message = "Successfully updated" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Failed to update user" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.EMAIL, model.PASSWORD, model.IS_REMEMBER, lockoutOnFailure: false);

            if (result.Succeeded)
                return Json(new { success = true, message = "Successfully logged in" });

            return Json(new { success = false, message = "Invalid login attempt" });
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Json(new { success = true, message = "Successfully logged out" });
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        private RegisterVM GetRegisterViewModel()
        {
            var returnURL = Url.Content("~/");

            if (!_roleManager.RoleExistsAsync(SD.UserRole.ADMIN.ToString()).Result)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.UserRole.ADMIN.ToString())).Wait();
                _roleManager.CreateAsync(new IdentityRole(SD.UserRole.CUSTOMER.ToString())).Wait();
            }

            return new RegisterVM
            {
                ROLE_LIST = _roleManager.Roles.Select(fw => new SelectListItem
                {
                    Text = fw.Name,
                    Value = fw.Name
                }),
                REDIRECT_URL = returnURL
            };
        }
    }
}
