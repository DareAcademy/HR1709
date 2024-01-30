using HR1709.Models;
using HR1709.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR1709.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AccountsController : Controller
    {
        IAccountService accountService;
        public AccountsController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        public IActionResult createAccount()
        {
            return View("createAccount");
        }

        public async Task<IActionResult> Singup(SignupDTO signupDTO)
        {
            var result= await accountService.CreateAccount(signupDTO);
            ViewData["result"] = result;
            return View("createAccount");
        }

        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return View("SignIn");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(SigninDTO signinDTO)
        {
            var result=await accountService.login(signinDTO);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewData["msg"] = "Invalid username or password";
                return View("SignIn");
            }
        }

        public IActionResult NewRole()
        {
            return View("NewRole");
        }

        public async Task<IActionResult> CreateRole(RoleDTO roleDTO)
        {
            var result = await accountService.CreateRole(roleDTO);
            ViewData["Result"] = result;
            return View("NewRole");
        }

        public async Task<IActionResult> UserList()
        {
            List<UserDTO> users= await accountService.getUsers();
            return View("UserList",users);
        }

        public async Task<IActionResult> userRoles(string userId)
        {
            List<vmRole> userRoles = await accountService.getRoles(userId);
            return View("UserRoles",userRoles);
        }

        public async Task<IActionResult> UpdateRole(List<vmRole> liRoles)
        {
            await accountService.UpdateRoles(liRoles);
            List<vmRole> roles = await accountService.getRoles(liRoles[0].UserId);
            return View("UserRoles", roles);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
           await accountService.Signout();

            return RedirectToAction("SignIn");
        }

    }
}
