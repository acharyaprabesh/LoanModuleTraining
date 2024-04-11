using LoanModule.API.RequestModel;
using LoanModule.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
                _authService=authService;
        }
        [HttpPost("GetLoginToke")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLoginTokenAsnyc(LoginRequestModel model)
        {
          var token=await  _authService.GetLoginToken(model);
            return Ok(token);
        }
    }
}
