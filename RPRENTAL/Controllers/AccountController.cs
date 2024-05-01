using DataService.DTO;
using DataService.Implementation;
using DataService.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model;
using RPRENTAL.ViewModels;
using StaticUtility;
using Stripe.Treasury;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;

namespace RPRENTAL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IWorker _IWorker;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly IResetPasswordService _IResetPasswordService;

        public AccountController(IWorker IWorker, UserManager<ApplicationUser> ApplicationUser, SignInManager<ApplicationUser> SignInManager, RoleManager<IdentityRole> RoleManager, IResetPasswordService iResetPasswordService)
        {
            _IWorker = IWorker;
            _UserManager = ApplicationUser;
            _SignInManager = SignInManager;
            _RoleManager = RoleManager;
            _IResetPasswordService = iResetPasswordService; 
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
        public async Task<IActionResult> Delete(string email)
        {
            try
            {

                if (email == "rolimer_pono@yahoo.com") //Temporary
                {
                    return Json(new { success = false, message="This user not allowed to delete." });
                }

                var objUser = await _UserManager.FindByEmailAsync(email);
                if (objUser == null)
                    return Json(new { success = false, message = "User not found." });

                var objUserRole = (await _UserManager.GetRolesAsync(objUser)).FirstOrDefault();
                if (objUserRole != null)
                    await _UserManager.RemoveFromRoleAsync(objUser, objUserRole);

                await _UserManager.DeleteAsync(objUser);
                _IWorker.tbl_User.Remove(objUser);

                return Json(new { success = true, message = "Successfully deleted." });
            }
            catch (Exception ex)
            {             
                return Json(new { success = false, message = "An error occurred while deleting the user." });
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
                    return Json(new { success = true, message = "Successfully login" , role= SD.UserRole.ADMIN.ToString()});
                }
                else
                {
                    return Json(new { success = true, message = "Successfully login", role="" });
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

        [HttpPost]
        public async Task<IActionResult> ForgotPassword([Required, EmailAddress] string email)
        {
            if (_SignInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Email = email;

            if (!ModelState.IsValid)
            {
                ViewBag.EmailError = ModelState["email"]?.Errors.First().ErrorMessage ?? "Invalid Email Address";
                return View();
            }

            var user = await _UserManager.FindByEmailAsync(email);

            if (user != null)
            {
               
                string token_generated = await _UserManager.GeneratePasswordResetTokenAsync(user);            
                string otp_generated = SD.GenerateOTP();
                ResetPassword objResetPassword = new ResetPassword();
               

                Email objEmail = new Email();
                objEmail.SenderMail = "sycopons2010@gmail.com";
                objEmail.SenderName = "THE KWANO";
                objEmail.RecieverName = user.UserName!;
                objEmail.RecieverEmail = user.Email!;
                objEmail.Subject = "Password Reset";
                objEmail.TextContent = "Dear " + user.UserName + ",\n\n" +
                                        "Please find the OTP below:\n\n" +
                                        "<strong>" + otp_generated + "</strong>\n\n" +
                                        "Kind Regards";


                Boolean is_success = SD.MailSend(objEmail);

                objResetPassword.Email = user.Email!;
                objResetPassword.Token = token_generated;
                objResetPassword.OTP = otp_generated;
                objResetPassword.ExpirationDate = DateTime.Now.AddMinutes(3);
                objResetPassword.CreatedDate = DateTime.Now;

                _IResetPasswordService.Create(objResetPassword);
                return Json(new { success = true, message = "Please check your email for the OTP.", data = objResetPassword.Token });

            }

            return Json(new { sucess = false, message = "Something went wrong" });

        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPassword objReset)
        {
            var Password_Authentication = _IResetPasswordService.Get(objReset);    
            var objUser = await _UserManager.FindByEmailAsync(objReset.Email);

            if (objUser != null)
            {
                if(Password_Authentication.Email == objReset.Email
                    && Password_Authentication.OTP == objReset.OTP
                    && Password_Authentication.Token == objReset.Token) 
                { 
                    if(objReset.Password != objReset.ConfirmPassword 
                        || (string.IsNullOrEmpty(objReset.Password) 
                        || string.IsNullOrEmpty(objReset.ConfirmPassword))) 
                    {
                        return Json(new { success = false, message = "The password you entered was invalid" });
                    }
                    
                    if (DateTime.Now > Password_Authentication.ExpirationDate)
                    {
                        return Json(new { success = false, message = "OTP already expired. Please login within 3 minutes. Thank you." });
                    
                    }

                    await _UserManager.ResetPasswordAsync(objUser, objReset.Token, objReset.Password);
                    await _SignInManager.SignInAsync(objUser, isPersistent: false);

                    return Json(new { success = true, message = "Password successfully changed."});

                }

                return Json(new { success = false, message = "Credentials input are not valid", data = objReset });

            }           

            return Json(new { success = false, message = "Email entered not found.", data = objReset });
        }       

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}