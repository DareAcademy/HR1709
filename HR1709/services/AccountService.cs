using HR1709.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HR1709.services
{
    public class AccountService:IAccountService
    {
        SignInManager<ApplicationUser> signInManager;
        UserManager<ApplicationUser> usermanager;
        RoleManager<IdentityRole> rolemanager;
        public AccountService(UserManager<ApplicationUser> _usermanager, 
            SignInManager<ApplicationUser> _signInManager,
            RoleManager<IdentityRole> _rolemanager)
        {
            usermanager = _usermanager;
            signInManager = _signInManager;
            rolemanager = _rolemanager;
        }
        //3s
        public async Task<IdentityResult> CreateAccount(SignupDTO signupDTO)
        {
            ApplicationUser user = new ApplicationUser();
            user.Name = signupDTO.Name;
            user.Gender = signupDTO.Gender;
            user.DOB = signupDTO.DOB;
            user.UserName = signupDTO.Email;
            user.Email = signupDTO.Email;
            //user.PasswordHash = signupDTO.Password;
            var result= await usermanager.CreateAsync(user,signupDTO.Password);
            return result;
        }

        public async Task<SignInResult> login(SigninDTO signinDTO)
        {
            var result= await signInManager.PasswordSignInAsync(signinDTO.Username, signinDTO.Password, signinDTO.RememberMe, false);
            return result;
        }

        public async Task<IdentityResult> CreateRole(RoleDTO roleDTO)
        {
            IdentityRole role = new IdentityRole();
            role.Name = roleDTO.Name;

            var result=await rolemanager.CreateAsync(role);
            return result;
        }

        public async Task<List<UserDTO>> getUsers()
        {
            List<ApplicationUser> allusers= await usermanager.Users.ToListAsync();
            List<UserDTO> users = new List<UserDTO>();
            foreach (ApplicationUser item in allusers)
            {
                UserDTO user = new UserDTO();
                user.Id = item.Id;
                user.Name = item.Name;
                user.Email = item.Email;
                users.Add(user);
            }

            return users;
            

        }

        public async Task<List<vmRole>> getRoles(string userId)
        {
            List<IdentityRole> allroles = await rolemanager.Roles.ToListAsync();

            List<vmRole> roles = new List<vmRole>();
            foreach (IdentityRole item in allroles)
            {
                vmRole vm = new vmRole();
                vm.Id = item.Id;
                vm.Name = item.Name;
                vm.IsSelected = false;
                vm.UserId = userId;
                roles.Add(vm);
            }

            var user = await usermanager.FindByIdAsync(userId);
            var userRoles = await usermanager.GetRolesAsync(user);

            foreach (vmRole item in roles)
            {
                if (userRoles.Contains(item.Name) == true)
                {
                    item.IsSelected = true;
                }
            }

            return roles;


        }

        public async Task UpdateRoles(List<vmRole> liUserRoles)
        {
            // id user => user

            foreach (vmRole item in liUserRoles)
            {
                ApplicationUser user = await usermanager.FindByIdAsync(item.UserId);
                if (item.IsSelected == true)
                {
                    if (await usermanager.IsInRoleAsync(user, item.Name) == false)
                    {
                        await usermanager.AddToRoleAsync(user, item.Name);
                    }
                }
                else
                {
                    if (await usermanager.IsInRoleAsync(user, item.Name) == true)
                    {
                        await usermanager.RemoveFromRoleAsync(user, item.Name);
                    }
                }
            }
        }

        public async Task Signout()
        {
             await signInManager.SignOutAsync();
        }

    }
}
