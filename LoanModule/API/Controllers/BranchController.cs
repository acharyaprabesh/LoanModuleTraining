using LoanModule.API.RequestModel;
using LoanModule.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BranchController : ControllerBase
    {
        private IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
                _branchService=branchService;
        }

        [HttpPost("CreateBranch")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateBranchAsync(List<BranchRequestModel> model)
        {
            var response= await _branchService.CreateBranchAsnyc(model.FirstOrDefault());
            return Ok(response);
        }
        [HttpGet("GetAllBranchList")]
        public async Task<IActionResult> GetAllBranchListAsync()
        {
            var BranchList= await _branchService.GetBranchAsync();
            return Ok(BranchList);
        }
    }
}
