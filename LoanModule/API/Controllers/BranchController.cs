using LoanModule.API.RequestModel;
using LoanModule.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
                _branchService=branchService;
        }

        [HttpPost("CreateBranch")]
        public async Task<IActionResult> CreateBranchAsync(BranchRequestModel model)
        {
            await _branchService.CreateBranchAsnyc(model);
            return Ok();
        }
        [HttpGet("GetAllBranchList")]
        public async Task<IActionResult> GetAllBranchListAsync()
        {
            var BranchList= await _branchService.GetBranchAsync();
            return Ok(BranchList);
        }
    }
}
