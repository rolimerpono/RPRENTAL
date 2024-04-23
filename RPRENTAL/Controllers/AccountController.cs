using DataService.Implementation;
using DataService.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model;
using RPRENTAL.ViewModels;
using StaticUtility;
using Stripe.Treasury;

namespace RPRENTAL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IWorker _IWorker;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly RoleManager<IdentityRole> _RoleManager;

        public AccountController(IWorker IWorker, UserManager<ApplicationUser> ApplicationUser, SignInManager<ApplicationUser> SignInManager, RoleManager<IdentityRole> RoleManager)
        {
            _IWorker = IWorker;
            _UserManager = ApplicationUser;
            _SignInManager = SignInManager;
            _RoleManager = RoleManager;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var objUsers = await _UserManager.Users.ToListAsync();

            IEnumerable<RegisterVM> objUserList = objUsers.Select(user => new RegisterVM
            {
                NAME = user.USER_NAME,
                PASSWORD = user.PasswordHash,
                CONFIRM_PASSWORD = user.PasswordHash,
                EMAIL = user.Email,
                PHONE_NUMBER = user.PhoneNumber,
                ROLE = _UserManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault()

            });

            return Json(new { data = objUserList });

        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }

        [HttpGet]
        public IActionResult Create()
        {
            var returnURL = Url.Content("~/");

            if (!_RoleManager.RoleExistsAsync(SD.UserRole.ADMIN.ToString()).GetAwaiter().GetResult())
            {
                _RoleManager.CreateAsync(new IdentityRole(SD.UserRole.ADMIN.ToString())).Wait();
                _RoleManager.CreateAsync(new IdentityRole(SD.UserRole.CUSTOMER.ToString())).Wait();
            }

            RegisterVM objUser = new RegisterVM();
            try
            {

                objUser = new RegisterVM()
                {
                    ROLE_LIST = _RoleManager.Roles.Select(fw => new SelectListItem
                    {
                        Text = fw.Name,
                        Value = fw.Name
                    }),
                    REDIRECT_URL = returnURL

                };


            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return PartialView("Create", objUser);

        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterVM objData)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser objUser = new ApplicationUser()
                {
                    USER_NAME = objData.NAME,
                    Email = objData.EMAIL,
                    PhoneNumber = objData.PHONE_NUMBER,
                    NormalizedEmail = objData.EMAIL.ToUpper(),
                    EmailConfirmed = true,
                    UserName = objData.EMAIL,
                    CREATED_DATE = DateTime.Now,

                };

                if (objData.PASSWORD != objData.CONFIRM_PASSWORD)
                {
                    return Json(new { success = false, message = "The password you entered did not matched." });
                }              

                var objUserManager = await _UserManager.CreateAsync(objUser, objData.PASSWORD);

                if (objUserManager.Succeeded)
                {
                    if (!string.IsNullOrEmpty(objData.ROLE))
                    {
                        await _UserManager.AddToRoleAsync(objUser, objData.ROLE);
                    }
                    else
                    {
                        await _UserManager.AddToRoleAsync(objUser, SD.UserRole.CUSTOMER.ToString());
                    }

                    return Json(new { success = true, message = "Successfully registered" });
                }
                else
                {
                    return Json(new { success = false, message = "The email or password entered was invalid. Please try again." });
                }

            }

            return Json(new { success = false, message = "Something went wrong" });

        }

        public async Task<IActionResult> Update(string email)
        {
            var objUser = await _UserManager.FindByEmailAsync(email);

            RegisterVM objRegister = new RegisterVM();

            objRegister.EMAIL = objUser.Email;
            objRegister.NAME = objUser.USER_NAME;
            objRegister.PHONE_NUMBER = objUser.PhoneNumber;
            objRegister.ROLE = _UserManager.GetRolesAsync(objUser).GetAwaiter().GetResult().FirstOrDefault();
            objRegister.ROLE_LIST = _RoleManager.Roles.Select(fw => new SelectListItem
            {
                Text = fw.Name,
                Value = fw.Name
            });


            return PartialView("Update", objRegister);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RegisterVM objData)
        {
            var objUser = await _UserManager.FindByEmailAsync(objData.EMAIL);
            var objUserRole = _UserManager.GetRolesAsync(objUser).GetAwaiter().GetResult().FirstOrDefault();


            try
            {

                await _UserManager.RemoveFromRoleAsync(objUser, objUserRole);
                await _UserManager.AddToRoleAsync(objUser, objData.ROLE);

                objUser.USER_NAME = objData.NAME;
                objUser.PhoneNumber = objData.PHONE_NUMBER;

                if (!String.IsNullOrEmpty(objData.PASSWORD))
                {
                    var token = await _UserManager.GeneratePasswordResetTokenAsync(objUser);
                    await _UserManager.ResetPasswordAsync(objUser, token, objData.PASSWORD);
                }

                await _UserManager.UpdateAsync(objUser);

                return Json(new { success = true, message = "Successfully registered" });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Something went wrong" });
            }

        }


        [HttpPost]
        public IActionResult Delete(string email)
        {
            var objUser = _IWorker.tbl_User.Get(fw => fw.Email.ToLower() == email.ToLower());

            if (objUser != null)
            {
                _IWorker.tbl_User.Remove(objUser);

                return Json(new { success = true, message = "Successfully deleted." });
            }
            else
            {
                return Json(new { success = false, message = "Something went wrong." });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var objSignIn = await _SignInManager.PasswordSignInAsync(loginVM.EMAIL, loginVM.PASSWORD, loginVM.IS_REMEMBER, lockoutOnFailure: false);

            if (objSignIn.Succeeded)
            {
                var objUser = await _UserManager.FindByEmailAsync(loginVM.EMAIL);

                if (await _UserManager.IsInRoleAsync(objUser, SD.UserRole.ADMIN.ToString()))
                {
                    return Json(new { success = true, message = "Successfully login" });
                }
                else
                {
                    return Json(new { success = true, message = "Successfully login" });
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid user login or password. Please try again." });
            }

        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM objData)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser objUser = new ApplicationUser()
                {
                    USER_NAME = objData.NAME,
                    Email = objData.EMAIL,
                    PhoneNumber = objData.PHONE_NUMBER,
                    NormalizedEmail = objData.EMAIL.ToUpper(),
                    EmailConfirmed = true,
                    UserName = objData.EMAIL,
                    CREATED_DATE = DateTime.Now,

                };

                if (objData.PASSWORD != objData.CONFIRM_PASSWORD)
                {
                    return Json(new { success = false, message = "The password you entered did not matched." });
                }

                var objUserManager = await _UserManager.CreateAsync(objUser, objData.PASSWORD);

                if (objUserManager.Succeeded)
                {
                    if (!string.IsNullOrEmpty(objData.ROLE))
                    {
                        await _UserManager.AddToRoleAsync(objUser, objData.ROLE);
                    }
                    else
                    {
                        await _UserManager.AddToRoleAsync(objUser, SD.UserRole.CUSTOMER.ToString());
                    }

                    await _SignInManager.SignInAsync(objUser, isPersistent: false);

                    return Json(new { success = true, message = "Successfully registered" });
                }
                else
                {
                    return Json(new { success = false, message = "The email or password entered was invalid. Please try again." });
                }

            }

            return Json(new { success = true, message = "Successfully registered" });

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();

            return Json(new { success = true, message = "Successfully logout" });

        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}