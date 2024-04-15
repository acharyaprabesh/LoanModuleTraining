using AutoMapper;
using LoanModule.API.Models;
using LoanModule.API.RequestModel;
using LoanModule.API.ResponseModel;
using LoanModule.Repositories.Interface;
using LoanModule.Service.Interface;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoanModule.Service.Implementation
{
    public class AuthService : IAuthService
    {
        private IGenericRepository _genericRepository;
        private IConfiguration _configuration;
        private IMapper _mapper;
        public AuthService(IGenericRepository genericRepository, IMapper mapper,IConfiguration configuration)
        {
                _genericRepository = genericRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<SystemResponse>  GetLoginToken(LoginRequestModel model)
        {
            var LoginMap = _mapper.Map<LoginModel>(model);
            LoginMap.Flag = 'L';
            var response = await _genericRepository.InsertAsync("spAuth", LoginMap);
            if(response.Status)
            {
                LoginMap.Flag = 'D';
                var UseModel = await _genericRepository.GetAsync<UserDetailsModel>("spAuth", LoginMap);

                LoginMap.Flag = 'P';
                var PermissionList = await _genericRepository.GetAllAsync<PermissionModel>("spAuth", LoginMap);

                string Token = this.CreateToken(UseModel, PermissionList);
                response.Message = Token;
            }
            return response;
        }

        private string CreateToken(UserDetailsModel clientDetails,List<PermissionModel> permissions)
        {

            var permissionsClaims = new List<Claim>();

            foreach (var item in permissions)
            {
                permissionsClaims.Add(new Claim(item.PermissionType, item.PermissionValue));
            }

            var claims = new List<Claim>
            {
                        new Claim(ClaimTypes.Name, clientDetails.Name),
                       new Claim(ClaimTypes.StreetAddress, clientDetails.Address),
                       new Claim("UserId", clientDetails.UserID.ToString()),
                       new Claim(ClaimTypes.Role,clientDetails.Role)
            }.Union(permissionsClaims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._configuration.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
