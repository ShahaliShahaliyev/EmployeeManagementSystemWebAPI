using EmployeeManagementAPI.Application.Abstractions.Services;
using EmployeeManagementAPI.Application.Abstractions.Token;
using EmployeeManagementAPI.Application.DTOs;
using EmployeeManagementAPI.Application.Exceptions;
using EmployeeManagementAPI.Application.Features.Commands.Users.LoginUser;
using EmployeeManagementAPI.Application.Helpers;
using EmployeeManagementAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly HttpClient _httpClient;
        readonly IConfiguration _configuration;
        readonly IUserService _userService;
        readonly IMailService _mailService;

        public AuthService(ITokenHandler tokenHandler, SignInManager<User> signInManager, UserManager<User> userManager, HttpClient httpClient, IConfiguration configuration, IUserService userService, IMailService mailService)
        {
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _userManager = userManager;
            _httpClient = httpClient;
            _configuration = configuration;
            _userService = userService;
            _mailService = mailService;
        }

        public async Task<TokenDTO> LoginAsync(string usernameOrEmail, string password)
        {
            User? user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(usernameOrEmail);
            if (user == null)
                throw new NotFoundUsernameException("Username or password incorrect");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {
                TokenDTO token = _tokenHandler.CreateAccessToken(5, user);
                return token;
            }
            throw new NotImplementedException();
        }

        public async Task PasswordResetAsync(string email)
        {
            User? user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                string resetToken = await
                    _userManager.GeneratePasswordResetTokenAsync(user);

              resetToken =   resetToken.UrlEncode();

               await _mailService.SendPasswordResetMailAsync(email, user.Id, resetToken);
            }
        }

        public async Task<bool> VerifyResetTokenAsync(string resetToken, int userId)
        {
           User? user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
               //byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
               // resetToken = Encoding.UTF8.GetString(tokenBytes);

                resetToken = resetToken.UrlDecode();

                return await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider,
                    "ResetPassword", resetToken);

            }

            return false;
        }
    }
}
