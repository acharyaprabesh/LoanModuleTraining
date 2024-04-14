using LoanModule.API.RequestModel;
using LoanModule.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LoanModule.API.Controllers
{
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
    }
}
