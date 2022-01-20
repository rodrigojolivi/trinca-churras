using Microsoft.AspNetCore.Mvc;
using System;
using TrincaChurras.API.ViewModels.Account;
using TrincaChurras.Core.Interfaces.Repositories;
using TrincaChurras.Infra.Security;

namespace TrincaChurras.API.Controllers.v1
{
    [Route("api/v1/account")]
    public class AccountController : CustomController
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AccountController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var user = _userRepository.FindUser(loginViewModel.Email, loginViewModel.Password);

            if (user == null)
                return NotFound();

            var accessToken = _tokenService.GenerateToken(user);

            return Ok(new { createdAt = DateTime.Now, accessToken });
        }
    }
}
