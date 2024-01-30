using HR1709.Models;
using Microsoft.AspNetCore.Identity;

namespace HR1709.services
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateAccount(SignupDTO signupDTO);

        Task<SignInResult> login(SigninDTO signinDTO);

        Task<IdentityResult> CreateRole(RoleDTO roleDTO);

        Task<List<UserDTO>> getUsers();

        Task<List<vmRole>> getRoles(string userId);

        Task UpdateRoles(List<vmRole> liUserRoles);

        Task Signout();
    }
}
