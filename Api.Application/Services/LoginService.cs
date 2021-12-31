using System;
using System.IdentityModel.Tokens.Jwt;
using Api.Application.Dtos.Login;
using Api.Application.Security;
using Api.Application.Interfaces;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using AutoMapper;
using Api.Application.Dtos.User;

namespace Api.Application.Services
{
    public class LoginService : ILoginService
    {

        private IConfiguration _configuration { get; set; }
        private IUserRepository _repository;
        private IMapper _mapper;

        public LoginService(IUserRepository repository,
            IConfiguration configuration, IMapper mapper)
        {
            _repository = repository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<object> FindByLoginAsync(LoginDto user)
        {
            if (user != null && !string.IsNullOrWhiteSpace(user.Email) && !string.IsNullOrWhiteSpace(user.Password))
            {
                var baseUser = await _repository.FindByLoginAsync(user.Email, user.Password);
                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = $"email: {user.Email} e/ou senha esta errado ou usuário inativo"

                    };
                }
                else
                {
                    var result = _mapper.Map<UserDto>(baseUser);
                    var claims = new[]
                           {
                            new Claim(JwtRegisteredClaimNames.Name, result.UserName),
                            new Claim(JwtRegisteredClaimNames.Email, result.UserEmail),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                           };

                    // Genarate secret key
                    var privateKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

                    //Generate digital sign
                    var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

                    //Define time to expire
                    var expiration = DateTime.UtcNow.AddMinutes(2);

                    //Generate the Token
                    JwtSecurityToken token = new JwtSecurityToken(

                        issuer: _configuration["JWT:Issuer"],

                        audience: _configuration["JWT:Audience"],

                        claims: claims,

                        expires: expiration,

                        signingCredentials: credentials
                        );
                    var Token = new JwtSecurityTokenHandler().WriteToken(token);

                    return SuccessObject(DateTime.UtcNow, expiration, Token, result);

                }
            }
            else
            {
                return null;
            }
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, UserDto user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "Usuário Logado com sucesso"
            };
        }
    }
}