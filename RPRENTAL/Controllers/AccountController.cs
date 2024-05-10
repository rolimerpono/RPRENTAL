using DataService.DTO;
using DataService.Implementation;
using DataService.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using Model;
using RPRENTAL.ViewModels;
using StaticUtility;
using Stripe.TestHelpers.Treasury;
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
        private readonly IHelper _helper;
        private readonly ICompositeViewEngine _viewEngine;

        public AccountController(IWorker IWorker, UserManager<ApplicationUser> ApplicationUser, SignInManager<ApplicationUser> SignInManager, 
            RoleManager<IdentityRole> RoleManager, IResetPasswordService iResetPasswordService,
            IHelper helper, ICompositeViewEngine viewengine            
            )
        {
            _IWorker = IWorker;
            _UserManager = ApplicationUser;
            _SignInManager = SignInManager;
            _RoleManager = RoleManager;
            _IResetPasswordService = iResetPasswordService; 
            _helper = helper;
            _viewEngine = viewengine;
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
                Fullname = user.Fullname!,
                Password = user.PasswordHash!,
                ConfirmPassword = user.PasswordHash!,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber,
                Role = _UserManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault()

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

            if (!_RoleManager.RoleExistsAsync(SD.UserRole.Admin.ToString()).GetAwaiter().GetResult())
            {
                _RoleManager.CreateAsync(new IdentityRole(SD.UserRole.Admin.ToString())).Wait();
                _RoleManager.CreateAsync(new IdentityRole(SD.UserRole.Customer.ToString())).Wait();
            }

            RegisterVM objUser = new RegisterVM();
            try
            {

                objUser = new RegisterVM()
                {
                    RoleList = _RoleManager.Roles.Select(fw => new SelectListItem
                    {
                        Text = fw.Name,
                        Value = fw.Name
                    }),
                    RedirectUrl = returnURL

                };

                
                PartialViewResult pvr = PartialView("Create", objUser);
                string html_string = _helper.ViewToString(this.ControllerContext, pvr, _viewEngine);               

                return Json(new { success = true, message = "", htmlContent = html_string });


            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }
           
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterVM objData)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    ApplicationUser objUser = new ApplicationUser()
                    {
                        Fullname = objData.Fullname,
                        Email = objData.Email,
                        PhoneNumber = objData.PhoneNumber,
                        NormalizedEmail = objData.Email.ToUpper(),
                        EmailConfirmed = true,
                        UserName = objData.Email,
                        CreatedDate = DateTime.Now,

                    };

                    if (objData.Password != objData.ConfirmPassword)
                    {
                        return Json(new { success = false, message = SD.CrudTransactionsMessage.PasswordConfirm });
                    }

                    var objUserManager = await _UserManager.CreateAsync(objUser, objData.Password);

                    if (objUserManager.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(objData.Role))
                        {
                            await _UserManager.AddToRoleAsync(objUser, objData.Role);
                        }
                        else
                        {
                            await _UserManager.AddToRoleAsync(objUser, SD.UserRole.Customer.ToString());
                        }


                        return Json(new { success = true, message = SD.CrudTransactionsMessage.Save});
                    }
                    else
                    {
                        var objError = objUserManager.Errors.Select(error => error.Description).ToList();
                        return Json(new { success = false, message = objError }); ;
                    }

                }

                var modelStateError = ModelState.Values.SelectMany(error => error.Errors).Select(e => e.ErrorMessage).ToList();
                return Json(new { success = false, message = modelStateError });
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }

        }

        [HttpGet]
        public async Task<IActionResult> Update(string email)
        {
            try
            {
                var objUser = await _UserManager.FindByEmailAsync(email);

                RegisterVM objRegister = new RegisterVM();

                objRegister.Email = objUser.Email!;
                objRegister.Fullname = objUser.Fullname!;
                objRegister.PhoneNumber = objUser.PhoneNumber;
                objRegister.Role = _UserManager.GetRolesAsync(objUser).GetAwaiter().GetResult().FirstOrDefault();
                objRegister.RoleList = _RoleManager.Roles.Select(fw => new SelectListItem
                {
                    Text = fw.Name,
                    Value = fw.Name
                });


                PartialViewResult pvr = PartialView("Update", objRegister);
                string html_string = _helper.ViewToString(this.ControllerContext, pvr, _viewEngine);

                return Json(new { success = true, message = "", htmlContent = html_string });

       
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }
           
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(RegisterVM objData)
        {
            var objUser = await _UserManager.FindByEmailAsync(objData.Email);

            var objUserRole = _UserManager.GetRolesAsync(objUser).GetAwaiter().GetResult().FirstOrDefault() ?? "CUSTOMER";


            try
            {

                await _UserManager.RemoveFromRoleAsync(objUser, objUserRole);
                await _UserManager.AddToRoleAsync(objUser, objData.Role);

                objUser.Fullname = objData.Fullname;
                objUser.PhoneNumber = objData.PhoneNumber;

                if (!String.IsNullOrEmpty(objData.Password))
                {
                    var token = await _UserManager.GeneratePasswordResetTokenAsync(objUser);
                    await _UserManager.ResetPasswordAsync(objUser, token, objData.Password);
                }

                await _UserManager.UpdateAsync(objUser);

                return Json(new { success = true, message = SD.CrudTransactionsMessage.Edit});

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }

        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string email)
        {
            try
            {

                var objBooking  = _IWorker.tbl_Booking.Get(fw => fw.UserEmail == email);

                if (objBooking != null)
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.IsUserHasTransactions });
                }

                if (email == "rolimer_pono@yahoo.com") //Temporary
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.IsDefaultAdmin });
                }

                var objUser = await _UserManager.FindByEmailAsync(email);
                if (objUser == null)
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.RecordNotFound });

                var objUserRole = (await _UserManager.GetRolesAsync(objUser)).FirstOrDefault();
                if (objUserRole != null)
                    await _UserManager.RemoveFromRoleAsync(objUser, objUserRole);

                await _UserManager.DeleteAsync(objUser);
                _IWorker.tbl_User.Remove(objUser);

                return Json(new { success = true, message = SD.CrudTransactionsMessage.Delete });
            }
            catch (Exception ex)
            {             
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }
        }


        [HttpPost,ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            try
            {
                var objSignIn = await _SignInManager.PasswordSignInAsync(loginVM.Email, loginVM.Password, loginVM.IsRemember, lockoutOnFailure: false);

                if (objSignIn.Succeeded)
                {
                    var objUser = await _UserManager.FindByEmailAsync(loginVM.Email);

                    if (await _UserManager.IsInRoleAsync(objUser, SD.UserRole.Admin.ToString()))
                    {
                        return Json(new { success = true, message = SD.SystemMessage.Login, role = SD.UserRole.Admin.ToString() });
                    }
                    else
                    {
                        return Json(new { success = true, message = SD.SystemMessage.Login, role = "" });
                    }
                }
                else
                {
                    return Json(new { success = false, message = SD.SystemMessage.FailUserLogin });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = true, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }

        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM objData)
        {
            try
            {
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors)
                                         .Select(e => e.ErrorMessage)
                                         .ToList();

                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = errorMessages });
                }

                ApplicationUser objUser = new ApplicationUser()
                {
                    Fullname = objData.Fullname,
                    Email = objData.Email,
                    PhoneNumber = objData.PhoneNumber,
                    NormalizedEmail = objData.Email.ToUpper(),
                    EmailConfirmed = true,
                    UserName = objData.Email,
                    CreatedDate = DateTime.Now,

                };


                if (objData.Password != objData.ConfirmPassword)
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.PasswordConfirm });
                }

                var objUserManager = await _UserManager.CreateAsync(objUser, objData.Password);

                if (objUserManager.Succeeded)
                {
                    if (!string.IsNullOrEmpty(objData.Role))
                    {
                        await _UserManager.AddToRoleAsync(objUser, objData.Role);
                    }
                    else
                    {
                        await _UserManager.AddToRoleAsync(objUser, SD.UserRole.Customer.ToString());

                    }

                    await _SignInManager.SignInAsync(objUser, isPersistent: false);

                    return Json(new { success = true, message = SD.CrudTransactionsMessage.Save });
                }
                else
                {
                    var objError = objUserManager.Errors.Select(error => error.Description).ToList();
                    return Json(new { success = false, message = objError }); ;
                }                
            
            }
            catch(Exception ex)
            {
                return Json(new { success = false,message  = ex.Message + " " + SD.SystemMessage.ContactAdmin}); ;
            }

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _SignInManager.SignOutAsync();

                return Json(new { success = true, message = SD.SystemMessage.Logout });
            }
            catch(Exception ex)            
            {
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            
            }
            
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword([Required, EmailAddress] string email)
        {
            try
            {

                var user = await _UserManager.FindByEmailAsync(email);

                if (user == null)
                {
                    return Json(new {success =false , message = SD.CrudTransactionsMessage.RecordNotFound});
                }

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
                objResetPassword.ExpirationDate = DateTime.Now.AddMinutes(5);
                objResetPassword.CreatedDate = DateTime.Now;

                _IResetPasswordService.Create(objResetPassword);

                return Json(new { success = true, message = "Please check your email for the OTP.", data = objResetPassword.Token });                
              
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message  + " " + SD.SystemMessage.ContactAdmin});
            }


        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPassword objReset)
        {
            try
            {
                var Password_Authentication = _IResetPasswordService.Get(objReset);
                var objUser = await _UserManager.FindByEmailAsync(objReset.Email);

                if (objUser != null)
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.RecordNotFound, data = objReset });
                }

                if (Password_Authentication != null)
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.InvalidInput, data = objReset });
                }

                if (objReset.Password != objReset.ConfirmPassword
                    || (string.IsNullOrEmpty(objReset.Password)
                    || string.IsNullOrEmpty(objReset.ConfirmPassword)))
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.PasswordConfirm });
                }


                if (DateTime.Now > Password_Authentication.ExpirationDate)
                {
                    return Json(new { success = false, message = "The OTP you have entered was already expired. Please login within 3 minutes. Thank you." });
                }


                string user_role = _UserManager.GetRolesAsync(objUser).GetAwaiter().GetResult().FirstOrDefault()!.ToString().ToLower();
                await _UserManager.ResetPasswordAsync(objUser, objReset.Token, objReset.Password);
                await _SignInManager.SignInAsync(objUser, isPersistent: false);

                return Json(new { success = true, message = SD.CrudTransactionsMessage.Save, Role = user_role });

                    
            }
            catch(Exception ex)
            {
                return Json(new {success =false, message  = ex.Message + " " + SD.SystemMessage.ContactAdmin});
            }
        }       

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}