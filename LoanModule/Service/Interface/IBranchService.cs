using LoanModule.API.RequestModel;
using LoanModule.API.ResponseModel;

namespace LoanModule.Service.Interface
{
    public interface IBranchService
    {
        Task CreateBranchAsnyc(BranchRequestModel branch);
        Task<List<BranchResponseModel>> GetBranchAsync();
    }
}
