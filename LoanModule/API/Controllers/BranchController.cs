using LoanModule.API.RequestModel;
using LoanModule.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> CreateBranchAsync(BranchRequestModel model)
        {
            var Name = this.User.FindFirst(ClaimTypes.NameIdentifier);
            var UserId = this.User.FindFirstValue("UserId");
            model.CreatedBy = int.Parse(UserId);
            var response= await _branchService.CreateBranchAsnyc(model);
            return Ok(response);
        }
        [Authorize(Policy = "Branch.Read")]
        [HttpGet("GetAllBranchList")]
        public async Task<IActionResult> GetAllBranchListAsync()
        {
            var BranchList= await _branchService.GetBranchAsync();
            return Ok(BranchList);
        }
    }
}
