using LoanModule.API.RequestModel;
using LoanModule.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanModule.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UtilityController : ControllerBase
    {
        private readonly IUtilityService _utilityService;
        public UtilityController(IUtilityService utilityService)
        {
            _utilityService = utilityService;
        }
        [HttpPost("GenericAPI")]
        public async Task<IActionResult> GenericAPI(GenericAPIRequestModel genericAPIRequestModel)
        {
            var data = await _utilityService.GenericAPIAsync(genericAPIRequestModel);
            return Ok(data);
        }
        [HttpGet("GetDropDownList")]
        public async Task<IActionResult> GetDropDownList(string DropDownName,string? FilterValue)
        {
            var data = await _utilityService.GetDropDownListAsync(DropDownName,FilterValue);
            return Ok(data);
        }
    }
}
