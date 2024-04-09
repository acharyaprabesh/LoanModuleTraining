using LoanModule.API.Models;
using LoanModule.API.RequestModel;
using LoanModule.Repositories.Interface;
using System.Net;

namespace LoanModule.Repositories.Implementation
{
    public class BranchRepository : DapperService, IBranchRepository
    {
        private IConfiguration _configuration;
       
        public BranchRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
          
        }

        public async Task CreateBranchAsnyc(BranchRequestModel branch)
        {
            var result = await this.ExecuteAsync(
                "insert into tblBranch(BranchCode,BranchName,Address,PhoneNo,status,CreatedDate)" +
                "values (@BranchCode,@BranchName,@Address,@PhoneNo,@status,@CreatedDate)",
            new
            {
                BranchCode = branch.BranchCode,
                BranchName = branch.BranchName,
                Address = branch.Address,
                PhoneNo = branch.PhoneNo,
                status = branch.status,
                CreatedDate = branch.CreatedDate
            }

               ); ;
        }
    }
}
