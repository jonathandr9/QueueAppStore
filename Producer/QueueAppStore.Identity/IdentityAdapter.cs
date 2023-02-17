using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.Jwt.Model;
using Newtonsoft.Json;
using QueueAppStore.Domain.Adapters;
using QueueAppStore.Domain.Models;

namespace QueueAppStore.Identity
{
    public class IdentityAdapter : IIdentityAdapter
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppJwtSettings _appJwtSettings;

        public IdentityAdapter(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<AppJwtSettings> appJwtSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appJwtSettings = appJwtSettings.Value;
        }

        public async Task<string> Login(User user)
        {
            var result = await _signInManager.PasswordSignInAsync(
                user.UserName,
                user.Password,
                false,
                true);

            if (result.IsLockedOut)
                throw new Exception("Usuário Bloqueado");

            if (result.Succeeded == false)
                throw new Exception("Usuário ou Senha Incorretos");

            var userData = await _userManager.FindByNameAsync(user.UserName);
            var email = userData.Email;

            return GetFullJwt(email);
        }

        public async Task<Guid> RegisterUser(User user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.Email
            };

            var result = await _userManager.CreateAsync(
                identityUser,
                user.Password);

            if (result.Succeeded == false)
                throw new InvalidOperationException(
                    JsonConvert.SerializeObject(result.Errors));

            var userResponse = GetUserResponse(user.Email);


            return Guid.Parse(userResponse.UserToken.Id);
        }

        private string GetFullJwt()
        {
            return new JwtBuilder()
                .WithUserManager(_userManager)
                .WithJwtSettings(_appJwtSettings)
                .BuildToken();
        }
        private string GetFullJwt(string email)
        {
            return new JwtBuilder()
                .WithUserManager(_userManager)
                .WithJwtSettings(_appJwtSettings)
                .WithEmail(email)
                .WithJwtClaims()
                .WithUserClaims()
                .WithUserRoles()
                .BuildToken();
        }

        private UserResponse GetUserResponse(string email)
        {
            return new JwtBuilder()
                .WithUserManager(_userManager)
                .WithJwtSettings(_appJwtSettings)
                .WithEmail(email)
                .WithJwtClaims()
                .WithUserClaims()
                .WithUserRoles()
                .BuildUserResponse();
        }
    }
}